using System;
using WebSocketSharp;

namespace ClientReceiver
{
    public class WebsocketSharpClient : IWebsocketClientTest
    {
        private WebSocket _websocket;
        public WebsocketSharpClient() : base()
        {
            _websocket = new WebSocket("ws://localhost:8089/Relay");
            _websocket.OnMessage += OnMessage;
            _websocket.OnOpen += Websocket_OnOpen;
            _websocket.OnError += Websocket_OnError;
            _websocket.OnClose += Websocket_OnClose;
            _websocket.Connect();
        }

        private void Websocket_OnClose(object sender, CloseEventArgs e)
        {
            Console.WriteLine("connection close");
        }

        private void Websocket_OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("error event");
        }

        private void Websocket_OnOpen(object sender, EventArgs e)
        {
            Console.WriteLine("connection open");
        }

        private void OnMessage(object sender, MessageEventArgs e)
        {
            if (Listener != null)
            {
                Listener.Receive(e.Data);
            }
        }

        public override void Send(string message)
        {
            _websocket.Send(message);
        }
    }
}
