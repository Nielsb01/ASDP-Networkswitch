using System;
using System.Threading.Tasks;
using WebsocketsSimple.Client;
using WebsocketsSimple.Client.Events.Args;
using WebsocketsSimple.Client.Models;

namespace ClientReceiver
{
    public class SimpleSocketClient : IWebsocketClientTest
    {
        private IWebsocketClient _client;

        public SimpleSocketClient() : base()
        {
            _client = new WebsocketClient(new ParamsWSClient
            {
                Uri = "localhost",
                Port = 8088,
                IsWebsocketSecured = false
            });

            _client.MessageEvent += OnMessageEvent;
            _client.ConnectionEvent += OnConnectionEvent;
            _client.ErrorEvent += OnErrorEvent;

            _client.ConnectAsync();
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
            if(Listener != null)
            {
                Listener.Receive(args.Message);
            }
            return Task.CompletedTask;
        }

        public override async void Send(string message)
        {
            await _client.SendToServerAsync(message);
        }
    }
}
