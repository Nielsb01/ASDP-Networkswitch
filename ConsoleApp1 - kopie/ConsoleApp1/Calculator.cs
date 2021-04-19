using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SocketIOClient;

namespace ConsoleApp1
{
    public class Calculator
    {
        public static async Task Main(string[] args)
        {
            var client = new SocketIO("http://localhost:3000", new SocketIOOptions
            {
                EIO = 4,
                Reconnection = true
            });
           
            client.OnReceivedEvent += async (sender, e) =>
            {

            };
            
            client.OnConnected += async (sender, e) =>
            {
                Console.WriteLine("Connected");
                for (var i = 0; i < 1000; i++)
                {
                    await client.EmitAsync("test", i);
                }
            };
            
            await client.ConnectAsync();
            Console.ReadLine();
        }
    }
}