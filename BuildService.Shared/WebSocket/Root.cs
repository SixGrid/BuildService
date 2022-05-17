using System;
using System.Text;
using System.Collections.Generic;
using BuildService.Shared.WebSocketService;
using Newtonsoft.Json;
using BuildService.Shared.WebSocketProcessing;
using System.Linq;

namespace BuildService.Shared.WebSocket
{
    internal class Root : WebSocketServerWrapper
    {
        protected override void OnWebSocketMessage(WebSocketMessageEventArgs e, Server server)
        {
            if (server == null) throw new ArgumentNullException(nameof(server));
            Sessions.Sweep();
            var lines = e.Data.Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None);

            var typeName = lines[0];
            var rawJsonData = e.Data.Replace(lines[0], "");
            Type? jsonType = Type.GetType(typeName);
            if (!typeName.StartsWith(@"BuildService.Shared.WebSocketProcessing", StringComparison.Ordinal)) return;
            var dictTypeMap = server.WebSocketProcessingMatch;
            foreach (KeyValuePair<string, Type> pair in dictTypeMap)
            {
                if (!typeName.StartsWith(@"BuildService.Shared.WebSocketProcessing." + pair.Key,
                        StringComparison.Ordinal)) continue;
                var mi = typeof(JsonConvert)
                    .GetMethods()
                    .Where(x => x.Name == @"DeserializeObject")
                    .FirstOrDefault(x => x.IsGenericMethod);
                var objRef = mi.MakeGenericMethod(pair.Value);
                dynamic result = objRef.Invoke(typeof(JsonConvert), new object[] { rawJsonData }) ?? throw new InvalidOperationException();
                result?.Process(server, this);
                break;
            }
        }
    }
}
