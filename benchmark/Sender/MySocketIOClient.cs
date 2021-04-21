using System;
using SocketIOClient;

namespace Sender
{
    class MySocketIoClient : IWebsocketClientTest
    {
        SocketIO client;

        public MySocketIoClient()
        {
            client = new SocketIO("http://0.0.0.0:3000", new SocketIOOptions
            {
                EIO = 4, // Socket.io protocol version.
                Reconnection = true
            });

            client.OnConnected += (sender, e) =>
            {
                Console.WriteLine("Connected");
            };

            client.ConnectAsync();
        }

        public override async void Send(string message)
        {
            await client.EmitAsync("test", message);
        }
    }
}
