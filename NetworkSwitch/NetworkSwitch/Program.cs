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

    public class EchoAll : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Console.WriteLine("connection opened");
            base.OnOpen();
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Sessions.Broadcast(e.Data);
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
            String port = Environment.GetEnvironmentVariable("PORT");
            WebSocketServer wss = new WebSocketServer($"ws://0.0.0.0:{port}");
            wss.AddWebSocketService<Echo>("/Echo");
            wss.AddWebSocketService<EchoAll>("/EchoAll");

            wss.Start();
            Console.WriteLine($"started on port {port}");
            Console.ReadKey();
            wss.Stop();
        }


    }
}
