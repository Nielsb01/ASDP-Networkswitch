/*
    AIM SD ASD 2020/2021 S2 project
     
    Project name: Networkswitch
 
    This file is created by team: 5
     
    Goal of this file: prototype for networkswitch using WebSocketSharp
     
*/

using WebSocketSharp.Server;
using System;

namespace NetworkSwitch
{
    class NetworkSwitch
    {
        static void Main(string[] args)
        {
            string ip = "0.0.0.0";
            string port = "8089";
            if (Environment.GetEnvironmentVariable("PORT") != null)
            {
                port = Environment.GetEnvironmentVariable("PORT");
            }

            WebSocketServer wss = new WebSocketServer($"ws://{ip}:{port}");

            wss.AddWebSocketService<Relay>("/Relay");

            wss.Start();
            Console.WriteLine($"started on port {port}");
            Console.ReadKey();
            wss.Stop();
        }
    }   
}
