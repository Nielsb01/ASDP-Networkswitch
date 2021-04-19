using System;
using SocketIOClient;

namespace ConsoleApp1
{
    class MySocketIoClient : IWebsocketClientTest
    {
        SocketIO client;

        public MySocketIoClient()
        {
            client = new SocketIO("http://localhost:3000", new SocketIOOptions
            {
                EIO = 4,
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
