using System;
using BuildService.Shared.WebSocketService;

namespace BuildService.Shared.WebSocketProcessing
{
    public interface IBaseMessage
    {
        void Process(Server server, WebSocketServerWrapper wrapper);
    }
    public abstract class ProcessableMessage : IBaseMessage
    {
        public abstract void Process(Server server, WebSocketServerWrapper wrapper);
    }
}
