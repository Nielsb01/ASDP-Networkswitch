using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Clients
{
    public class WebsocketSharpClient : IWebsocketClientTest
    {
        private WebSocket websocket;
        public WebsocketSharpClient() : base()
        {
            websocket = new WebSocket("ws://localhost:8089/Relay");
            websocket.OnMessage += OnMessage;
            websocket.OnOpen += Websocket_OnOpen;
            websocket.OnError += Websocket_OnError;
            websocket.OnClose += Websocket_OnClose;
            websocket.Connect();
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
            if (listener != null)
            {
                listener.Receive(e.Data);
            }
        }

        public override void Send(string message)
        {
            websocket.Send(message);
        }
    }
}
