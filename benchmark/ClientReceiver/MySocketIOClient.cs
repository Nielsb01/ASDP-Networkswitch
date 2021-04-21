using System;
using SocketIOClient;

namespace ClientReceiver
{
    class MySocketIOClient : IWebsocketClientTest
    {
        public MySocketIOClient()
        {
            var client = new SocketIO("http://0.0.0.0:3000", new SocketIOOptions
            {
                EIO = 4, // Socket.io protocol version.
                Reconnection = true
            });

            client.OnReceivedEvent += (sender, e) =>
            {
                Listener.Receive(e.Response.GetValue<string>());
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
