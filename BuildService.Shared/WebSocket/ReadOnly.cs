using System;
using System.Text;
using System.Collections.Generic;
using BuildService.Shared.WebSocketService;
using Newtonsoft.Json;
using BuildService.Shared.WebSocketProcessing;
using System.Linq;

namespace BuildService.Shared.WebSocket
{
    internal class ReadOnly : WebSocketServerWrapper
    {
        protected override void OnWebSocketMessage(WebSocketMessageEventArgs e, Server server)
        {
            if (server == null) throw new ArgumentNullException(nameof(server));
            Sessions.Sweep();
        }
    }
}