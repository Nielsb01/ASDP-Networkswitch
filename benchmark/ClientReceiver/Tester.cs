using System;

namespace ClientReceiver
{
    class Tester
    {
        public static void Main(string[] args)
        {
            IListener listener = new MyListener();
            IWebsocketClientTest client;
            client = new MySocketIOClient();
            // client = new SimpleSocketClient();
            // client = new WebsocketSharpClient();
            
            client.SetListener(listener);

            Console.ReadLine();
            Console.WriteLine(listener.GetSum() / listener.GetCount());
            Console.WriteLine(listener.GetSum());
            Console.WriteLine(listener.GetCount());
            Console.ReadLine();
        }
    }
}
