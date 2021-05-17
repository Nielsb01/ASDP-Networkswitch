using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebsocketsSimple.Server;
using WebsocketsSimple.Server.Models;

namespace NetworkSwitch
{
    class NetworkSwitch
    {
        private static IWebsocketServer _server;

        static void Main(string[] args)
        {
            String port = Environment.GetEnvironmentVariable("PORT");
            IParamsWSServer wsParams = new ParamsWSServer
            {
                Port = Int32.Parse(port),
                ConnectionSuccessString = "Connected Succesfully"
            };

            _server = new WebsocketServer(wsParams);
            _server.MessageEvent += Server_MessageEvent;
            _server.ConnectionEvent += Server_ConnectionEvent;
            _server.ErrorEvent += Server_ErrorEvent;
            _server.ServerEvent += Server_ServerEvent;

            _server.StartAsync();
            Console.WriteLine($"server starterd on port {port}");
            Console.ReadLine();
            _server.StopAsync();
        }

        private static System.Threading.Tasks.Task Server_ServerEvent(object sender, PHS.Networking.Server.Events.Args.ServerEventArgs args)
        {
            Console.WriteLine("server event");
            return Task.CompletedTask;
        }

        private static System.Threading.Tasks.Task Server_ErrorEvent(object sender, WebsocketsSimple.Server.Events.Args.WSErrorServerEventArgs args)
        {
            Console.WriteLine($"error event: {args.Exception}");
            return Task.CompletedTask;
        }

        private static System.Threading.Tasks.Task Server_ConnectionEvent(object sender, WebsocketsSimple.Server.Events.Args.WSConnectionServerEventArgs args)
        {
            Console.WriteLine("connection event");
            return Task.CompletedTask;
        }

        private static System.Threading.Tasks.Task Server_MessageEvent(object sender, WebsocketsSimple.Server.Events.Args.WSMessageServerEventArgs args)
        {
            if(args.MessageEventType == PHS.Networking.Enums.MessageEventType.Receive)
            {
               sendToAllExcept(_server.Connections, args.Connection, args.Message);
            }
            return Task.CompletedTask;
        }

        private static async void sendToAllExcept(IConnectionWSServer[] connections, IConnectionWSServer except,  string message)
        {
            foreach (IConnectionWSServer connection in connections)
            {
                if(connection.ConnectionId != except?.ConnectionId)
                {
                    _server.SendToConnectionRawAsync(message, connection);
                }
            }
        }
    }
}
