using System;

namespace ClientReceiver
{
    public class MyListener : IListener
    {
        private int _count = 0;
        private long _sum = 0;
        public void Receive(string message)
        {
            //receive messages and sum the difference between current timestamp and sent timestamp and count messages
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
