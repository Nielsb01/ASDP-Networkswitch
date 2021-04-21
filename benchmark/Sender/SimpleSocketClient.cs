using System;
using System.Threading.Tasks;
using WebsocketsSimple.Client;
using WebsocketsSimple.Client.Events.Args;
using WebsocketsSimple.Client.Models;

namespace Sender
{
    public class SimpleSocketClient : IWebsocketClientTest
    {
        private IWebsocketClient client;

        public SimpleSocketClient() : base()
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

        private Task OnMessageEvent(object sender, WSMessageClientEventArgs args)
        {
            if(listener != null)
            {
                listener.Receive(args.Message);
            }
            return Task.CompletedTask;
        }

        public override async void Send(string message)
        {
            await client.SendToServerAsync(message);
        }
    }
}
