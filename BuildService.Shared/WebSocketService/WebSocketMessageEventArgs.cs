using System;
using WebSocketSharp;

namespace BuildService.Shared.WebSocketService
{
    public class WebSocketMessageEventArgs : EventArgs
    {
        public string Data { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public MessageEventArgs Message { get; set; }
    }
}
