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
