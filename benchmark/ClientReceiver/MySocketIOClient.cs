using System;
using SocketIOClient;

namespace ClientReceiver
{
    class MySocketIOClient : IWebsocketClientTest
    {
        public MySocketIOClient()
        {
            SocketIO client;
            
            client = new SocketIO("http://localhost:3000", new SocketIOOptions
            {
                EIO = 4,
                Reconnection = true
            });

            client.OnReceivedEvent += (sender, e) =>
            {
                listener.Receive(e.Response.GetValue<string>());
            };

            client.OnConnected += (sender, e) =>
            {
                Console.WriteLine("Connected");
            };

            client.ConnectAsync();
        }

        public override void Send(string message)
        {
            // Do nothing.
        }
    }
}
