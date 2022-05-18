using System;
using System.Collections.Generic;
using System.Text;
using BuildService.Shared.Build;
using BuildService.Shared.WebSocketService;
using WebSocketSharp;

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
                if (wrapper.State == WebSocketState.Open)
                    wrapper.SendResponse(args);
            };
            instance.appendEnvoromentVariables(additionalEnviromentVariables);
            instance.Start();
        }

        public string target { get; set; }
        public Dictionary<string, string> additionalEnviromentVariables = new Dictionary<string, string>();
    }
}