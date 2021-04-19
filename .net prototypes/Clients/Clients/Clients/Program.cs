using System;
using System.Threading.Tasks;
using WebsocketsSimple.Client;
using WebsocketsSimple.Client.Events.Args;
using WebsocketsSimple.Client.Models;

namespace Clients
{
    class program
    {
        static async Task Main(string[] args)
         {
            IWebsocketClientTest testSubject = new WebsocketSharpClient();
            Tester tester = new Tester(testSubject);
            tester.test();
            Console.ReadLine();
        }
    }
    
}
