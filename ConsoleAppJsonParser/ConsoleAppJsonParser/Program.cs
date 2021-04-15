using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleAppJsonParser
{
    class Program
    {
        HttpClient client = new HttpClient();
        
        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetHeader();
            await program.GetAction();
        }
        
        private async Task GetHeader()
        {
            string response = await client.GetStringAsync(
                "https://my-json-server.typicode.com/Nielsb01/JsonServer3/header");
            
            Console.WriteLine(response); //test input

            PayloadHeader header = JsonConvert.DeserializeObject<PayloadHeader>(response);
            
            Console.WriteLine("target: " + header.target); //test output
        }
        
        private async Task GetAction()
        {
           //TODO uitwerken actions getten aan de hand van header.actionType
        }

    }

    class PayloadHeader
    {
        public string target { get; set; }
        public Client origin { get; set; }
        public string actionType { get; set; }
    }
    
    class Client
    {
        public string name { get; set; }
        public int id { get; set; }
    }
    
    // class ChatAction
    // {
    //     public string target { get; set; }
    //     public string origin { get; set; }
    //     public string actionType { get; set; }
    // }
    
    // class MoveAction
    // {
    //     public int originLocX { get; set; }
    //     public int originLocY { get; set; }
    //     public int destinationLocX { get; set; }
    //     public int destinationLocY { get; set; }
    // }
    
    // class AttackAction
    // {
    //     public Creature attackTarget { get; set; } //"type": "zombie","id": 219,"hp": 20
    //     public int hitChance { get; set; }
    //     public int damage { get; set; }
    // }
}