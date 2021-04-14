
using WebSocketSharp;
using WebSocketSharp.Server;
using System;

namespace NetworkSwitch
{

    public class Echo : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Console.WriteLine("connection opened");
            base.OnOpen();
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Send(e.Data);
            Console.WriteLine($"received: {e.Data}");
            base.OnMessage(e);
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Console.WriteLine("connection closed");
            base.OnClose(e);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WebSocketServer wss = new WebSocketServer("ws://localhost:8088");
            wss.AddWebSocketService<Echo>("/Echo");

            wss.Start();
            Console.WriteLine("started on port 8088");
            Console.ReadKey();
            wss.Stop();
        }


    }
}
