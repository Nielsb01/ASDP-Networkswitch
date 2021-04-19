// using System;
// using System.Diagnostics;
// using System.Threading.Tasks;
// using SocketIOClient;
//
// namespace ClientReceiver
// {
//     class Program
//     {
//     //     public static async Task Main(string[] args)
//     //     {
//     //         Stopwatch stopwatch  = new Stopwatch();
//     //         int count = 0;
//     //         long sum = 0;
//     //         
//     var client = new SocketIO("http://localhost:3000", new SocketIOOptions
//     {
//         EIO = 4,
//         Reconnection = true
//     });
//     
//     client.OnReceivedEvent += (sender, e) =>
//     {
//         DateTime now = DateTime.UtcNow;
//         long unixTimeMilliseconds = new DateTimeOffset(now).ToUnixTimeMilliseconds();
//         sum += unixTimeMilliseconds - e.Response.GetValue<long>();
//         count++;
//         // Console.WriteLine("Response: " + (unixTimeMilliseconds - e.Response.GetValue<long>()));
//         // Console.WriteLine("RawLocal: " + unixTimeMilliseconds + " RawResponse: " + e.Response.GetValue<long>());
//         // if (count == 0)
//         // {
//         //     stopwatch.Start();
//         // }
//         //
//     //             // count++;
//     //             //
//     //             // if (count == 1000)
//     //             // {
//     //             //     stopwatch.Stop();
//     //             //     Console.WriteLine("ms between 1000 messages: " + stopwatch.ElapsedMilliseconds);
//     //             //     stopwatch = new Stopwatch();
//     //             //     count = 0;
//     //             // }
//     //         };
//     //         
//     //         client.OnConnected += (sender, e) =>
//     //         {
//     //             Console.WriteLine("Connected");
//     //         };
//     //         
//     //         await client.ConnectAsync();
//     //         Console.ReadLine();
//     //         Console.WriteLine(sum / count);
//     //         Console.WriteLine(sum);
//     //         Console.WriteLine(count);
//     //         Console.ReadLine();
//     //     }
//     // }
// }