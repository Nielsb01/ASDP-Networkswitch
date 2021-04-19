using System;
using System.Threading.Tasks;
using WebsocketsSimple.Client;
using WebsocketsSimple.Client.Events.Args;
using WebsocketsSimple.Client.Models;

namespace Clients
{
    public class SimpleSocketClient
    {
        IWebsocketClient client;

        public SimpleSocketClient()
        {
            client = new WebsocketClient(new ParamsWSClient
            {
                Uri = "localhost",
                Port = 8088,
                IsWebsocketSecured = false
            });

            client.MessageEvent += OnMessageEvent;
            client.ConnectionEvent += OnConnectionEvent;
            client.ErrorEvent += OnErrorEvent;

            client.ConnectAsync();
        }


        static async Task Main(string[] args)
        {
            IWebsocketClient client = new WebsocketClient(new ParamsWSClient
            {
                Uri = "localhost",
                Port = 8088,
                IsWebsocketSecured = false
            });

            client.MessageEvent += OnMessageEvent;
            client.ConnectionEvent += OnConnectionEvent;
            client.ErrorEvent += OnErrorEvent;

            await client.ConnectAsync();


            Console.WriteLine("Hello World!");
        }

        private static Task OnErrorEvent(object sender, WSErrorClientEventArgs args)
        {
            Console.WriteLine("error event");
            return Task.CompletedTask;
        }

        private static Task OnConnectionEvent(object sender, WSConnectionClientEventArgs args)
        {

            Console.WriteLine("connection event");
            return Task.CompletedTask;
        }

        private static Task OnMessageEvent(object sender, WSMessageClientEventArgs args)
        {
            Console.WriteLine("message event");
            return Task.CompletedTask;
        }
    }
}
