using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Threading;
using BuildService.Shared.Build;
using BuildService.Shared.Configuration;
using BuildService.Shared.WebSocketService;
using WebSocketSharp.Net;

namespace BuildService.Shared
{
    public class Server
    {
        List<Thread> ThreadList = new List<Thread>();
        List<WaitHandle> WaitHandleList = new List<WaitHandle>();

        public Dictionary<string, Type> WebSocketProcessingMatch = new Dictionary<string, Type>()
        {
            {@"BuildStatusMessage", typeof(WebSocketProcessing.BuildStatusMessage)},
            {@"AvailableBuildsMessage", typeof(WebSocketProcessing.AvailableBuildsMessage)},
            {@"ExecuteBuildMessage", typeof(WebSocketProcessing.ExecuteBuildMessage)}
        };

        public void InitalizeServer()
        {
            EventWaitHandle waithandleWebSocketServer = new EventWaitHandle(false, EventResetMode.ManualReset);
            Thread threadWebSocketServer = new Thread(new ThreadStart(() => Thread_WebSocketServer(waithandleWebSocketServer)));
            WaitHandleList.Add(waithandleWebSocketServer);
            ThreadList.Add(threadWebSocketServer);

            EventWaitHandle waithandleBuildController = new EventWaitHandle(false, EventResetMode.ManualReset);
            Thread threadBuildController = new Thread(new ThreadStart(() => Thread_BuildController(waithandleBuildController)));
            WaitHandleList.Add(waithandleBuildController);
            ThreadList.Add(threadBuildController);
            
            EventWaitHandle waithandleHTTPServer = new EventWaitHandle(false, EventResetMode.ManualReset);
            Thread threadHTTPServer  = new Thread(new ThreadStart(() => WebServer.Instance.WebServerThread(waithandleBuildController)));
            WaitHandleList.Add(waithandleHTTPServer);
            ThreadList.Add(threadHTTPServer);
        }

        public Thread RegisterThread(ThreadStart tstart)
        {
            EventWaitHandle waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
            Thread thread = new Thread(tstart);
            WaitHandleList.Add(waitHandle);
            ThreadList.Add(thread);
            return thread;
        }

        public void StartThreads()
        {
            foreach (Thread thread in ThreadList)
            {
                thread.Start();
            }

            WaitHandle.WaitAll(WaitHandleList.ToArray());
        }

        public BuildController? BuildController;

        public void Thread_BuildController(EventWaitHandle handle)
        {
            BuildController = new BuildController(this, new BuildControllerOptions
            {
                BasePath = ConfigManager.sysRootDataLocation
            });

            handle.Set();
        }

        public string WebSocketServerAddress = String.Format(@"ws://{0}:{1}", ConfigManager.svAddress, ConfigManager.svwsPort);

        public WebSocketServerExtension WebSocketServer;
        
        public void Thread_WebSocketServer(EventWaitHandle handle)
        {
            WebSocketServer = WSBuilder.CreateServer(WebSocketServerAddress);

            WebSocketServer.AddWebSocketService<WebSocket.Root>(@"/");
            WebSocketServer.Realm = String.Format(@"BuildService");

            WebSocketServer.UserCredentialsFinder = WebSocketServerCredentialHandle;
            WebSocketServer.AuthenticationSchemes = AuthenticationSchemes.Basic;
            
            WebSocketServer.Start();

            Console.WriteLine(@"Websocket Server started at: " + WebSocketServerAddress);

            handle.Set();
        }

        private static NetworkCredential WebSocketServerCredentialHandle(IIdentity user)
        {
            var auth = (HttpBasicIdentity)user;
            if (auth.Name != ConfigManager.authUsername)
                return null;
            if (auth.Password != ConfigManager.authPassword)
                return null;
            return new NetworkCredential(auth.Name, auth.Password);
        }
    }
}
