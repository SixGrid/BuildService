using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebSocketSharp;
using System.Text;
using System.Threading.Tasks;
using BuildService.Client.WinForms.Authentication;

namespace BuildService.Client.WinForms.Network
{
    internal enum ServerConnectionState
    {
        OPEN,
        CLOSED,
        WAITING
    }
    internal class ServerConnection
    {
        internal ServerConnection(IPAddress address)
            : this(address, 8090) { }
        internal ServerConnection(byte[] address)
            : this(new IPAddress(address)) { }
        internal ServerConnection(byte[] address, uint port)
            : this(new IPAddress(address), port) { }
        internal ServerConnection()
            : this(new byte[] { 127, 0, 0, 1 }, 8090) { }
        internal ServerConnection(IPAddress address, uint port)
        {
            IpAddress = address;
            Port = port;
            State = ServerConnectionState.CLOSED;
        }
        internal bool Connected { get; private set; }
        internal ServerConnectionState State { get; private set; }

        internal bool Secure { get; private set; }
        internal IPAddress IpAddress { get; private set; }
        internal uint Port { get; private set; }
        internal string Path { get; private set; }

        private AuthenticationProfile authentication = null;
        internal AuthenticationProfile Authentication
        {
            get
            {
                return authentication;
            }
            set
            {
                if (!Connected)
                    authentication = value;
            }
        }

        private WebSocket webSocketClient;

        internal static string BuildURL(ServerConnection instance)
        {
            List<string> data = new List<string>();
            if (instance.Secure)
                data.Append(@"wss://");
            else
                data.Append(@"ws://");

            if (instance.Authentication != null)
            {
                if (instance.Authentication.Username.Length > 0)
                    data.Append($@"{instance.Authentication.Username}");
                if (instance.Authentication.Passphrase.Length > 0)
                    data.Append($@":{instance.Authentication.Passphrase}");
                data.Append(@"@");
            }

            data.Append(instance.IpAddress.ToString());
            if (instance.Port > 0)
                data.Append($@":{instance.Port}");
            if (instance.Path.Length > 0)
                data.Append(instance.Path);

            return string.Join(string.Empty, data.ToArray());
        }


        internal async void Connect()
        {
            if (Connected) return;
            State = ServerConnectionState.WAITING;
            webSocketClient = new WebSocket(BuildURL(this));
            webSocketClient.OnMessage += OnMessage;
            webSocketClient.OnError += OnError;
            webSocketClient.OnOpen += OnOpen;
            webSocketClient.OnClose += OnClose;
        }

        internal void OnMessage(object sender, MessageEventArgs args)
        {

        }
        internal void OnError(object sender, WebSocketSharp.ErrorEventArgs args)
        {

        }
        internal void OnOpen(object sender, EventArgs args)
        {
            State = ServerConnectionState.OPEN;
        }
        internal void OnClose(object sender, CloseEventArgs args)
        {
            State = ServerConnectionState.CLOSED;
        }
    }
}
