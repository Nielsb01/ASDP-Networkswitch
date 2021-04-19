/*
    AIM SD ASD 2020/2021 S2 project
     
    Project name: Networkswitch
 
    This file is created by group 5 Wim Beukers
     
    Goal of this file: prototype for networkswitch using WebsocketsSimple
     
*/


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebsocketsSimple.Server;
using WebsocketsSimple.Server.Models;

namespace NetworkSwitch
{
    class Program
    {
        private static IWebsocketServer Server;

        static void Main(string[] args)
        {
            IParamsWSServer wsParams = new ParamsWSServer
            {
                Port = 8088,
                ConnectionSuccessString = "Connected Succesfully"
            };

            Server = new WebsocketServer(wsParams);
            Server.MessageEvent += Server_MessageEvent;
            Server.ConnectionEvent += Server_ConnectionEvent;
            Server.ErrorEvent += Server_ErrorEvent;
            Server.ServerEvent += Server_ServerEvent;

            Server.StartAsync();
            Console.WriteLine("server starterd on port 8088");
            Console.ReadLine();
            Server.StopAsync();
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
               //sendToAllExcept(Server.Connections, null, args.Message);
               sendToAllExcept(Server.Connections, args.Connection, args.Message);
            }
            //Console.WriteLine("message event");
            return Task.CompletedTask;
        }

        private static async void sendToAllExcept(IConnectionWSServer[] connections, IConnectionWSServer except,  string message)
        {
            foreach (IConnectionWSServer connection in connections)
            {
                if(connection.ConnectionId != except?.ConnectionId)
                {
                    Server.SendToConnectionRawAsync(message, connection);
                }
            }
        }
    }
}
