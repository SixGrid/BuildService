using System;
using System.Collections.Generic;
using System.Text;
using BuildService.Shared.WebSocketService;

namespace BuildService.Shared.WebSocketProcessing
{
    public class ExecuteBuildMessage : ProcessableMessage
    {
        public override void Process(Server server, WebSocketServerWrapper wrapper)
        {
            
        }

        public string organization { get; set; }
        public string repository { get; set; }
    }
}