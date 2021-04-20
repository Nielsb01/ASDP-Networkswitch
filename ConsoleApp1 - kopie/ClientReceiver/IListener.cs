//     AIM SD ASD 2020/2021 S2 project
// 
//     Project name: [to be determined]
// 
//     This file is created by group 5 [Luuk, Niels, Pepijn, Wim, Jordi]
// 
//     Goal of this file: [making_the_system_work]

namespace ClientReceiver
{
    public interface IListener
    {
        public void Receive(string message);
        public long GetSum();
        public int GetCount();
    }
}