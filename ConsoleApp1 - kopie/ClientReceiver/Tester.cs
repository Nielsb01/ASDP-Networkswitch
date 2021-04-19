//     AIM SD ASD 2020/2021 S2 project
// 
//     Project name: [to be determined]
// 
//     This file is created by group 5 [Luuk, Niels, Pepijn, Wim, Jordi]
// 
//     Goal of this file: [making_the_system_work]

using System;
using ConsoleApp1;

namespace ClientReceiver
{
    class Tester
    {
        public static void Main(string[] args)
        {
            IListener listener = new MyListener();
            IWebsocketClientTest client = new MySocketIOClient();
            
            client.SetListener(listener);

            Console.ReadLine();
            Console.WriteLine(listener.GetSum() / listener.GetCount());
            Console.WriteLine(listener.GetSum());
            Console.WriteLine(listener.GetCount());
            Console.ReadLine();
        }
    }
}