//     AIM SD ASD 2020/2021 S2 project
// 
//     Project name: [to be determined]
// 
//     This file is created by group 5 [Luuk, Niels, Pepijn, Wim, Jordi]
// 
//     Goal of this file: [making_the_system_work]

using System;

namespace ClientReceiver
{
    public class MyListener : IListener
    {
        private int _count = 0;
        private long _sum = 0;
        public void Receive(string message)
        {
            DateTime now = DateTime.UtcNow;
            long unixTimeMilliseconds = new DateTimeOffset(now).ToUnixTimeMilliseconds();
            _sum += unixTimeMilliseconds - long.Parse(message);
            _count++;
        }

        public long GetSum()
        {
            return _sum;
        }

        public int GetCount()
        {
            return _count;
        }
    }
}