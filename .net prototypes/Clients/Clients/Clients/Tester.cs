using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
    class Tester : IListener
    {
        IWebsocketClientTest subject;
        int counter;
        Stopwatch stopwatch;

        public Tester(IWebsocketClientTest subject)
        {
            this.subject = subject;
            counter = 0;
            stopwatch = new Stopwatch();
        }

        public async Task test()
        {
            subject.SetListener(this);
            stopwatch.Start();
            counter = 1000;
            for(int i = 0; i < 1000; i++)
            {
                subject.Send($"test {i}");
            }
        }

        public void Receive(string message)
        {
            //Console.WriteLine(message);
            counter--;
            if (counter == 0)
            {
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
