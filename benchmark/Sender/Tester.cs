//     AIM SD ASD 2020/2021 S2 project
// 
//     Project name: [to be determined]
// 
//     This file is created by group 5 [Luuk, Niels, Pepijn, Wim, Jordi]
// 
//     Goal of this file: [making_the_system_work]

using System;

namespace Sender
{
    public class Tester
    {
        public static void Main(string[] args)
        {
            IWebsocketClientTest _websocketClientTest;
            _websocketClientTest = new MySocketIoClient();
            // _websocketClientTest = new SimpleSocketClient();
            // _websocketClientTest = new WebsocketSharpClient();
            int amount = 100000;
            
            Console.WriteLine("Press enter if connected!");
            Console.ReadLine();
            
            for (var i = 0; i < amount; i++)
            {
                DateTime now = DateTime.UtcNow;
                long unixTimeMilliseconds = new DateTimeOffset(now).ToUnixTimeMilliseconds();
                _websocketClientTest.Send(unixTimeMilliseconds.ToString());
            }
            
            Console.ReadLine();
        }
    }
}