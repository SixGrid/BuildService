using System;
using System.Collections.Generic;
using System.Text;
using BuildService.Shared.Build;
using BuildService.Shared.WebSocketService;

namespace BuildService.Shared.WebSocketProcessing
{
    public class ExecuteBuildMessage : ProcessableMessage
    {
        public override void Process(Server server, WebSocketServerWrapper wrapper)
        {
            if (server.BuildController == null) return;
            var buildable = server.BuildController.GetBuildable(target);
            if (buildable == null) return;
            var instance = new BuildInstance(server.BuildController, buildable);
            instance.BuildMessageEvent += (sender, args) =>
            {
                wrapper.SendResponse(args);
            };
            instance.Start();
        }

        public string target { get; set; }
    }
}