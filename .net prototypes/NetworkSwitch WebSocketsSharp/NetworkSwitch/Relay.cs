using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace NetworkSwitch
{
    public class Relay : WebSocketBehavior
    {
        protected override void OnOpen()
        {

            Console.WriteLine("connection opened");
            base.OnOpen();
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            sendToAllExcept(ID, e.Data);
            base.OnMessage(e);
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Console.WriteLine("connection closed");
            base.OnClose(e);
        }

        protected override void OnError(ErrorEventArgs e)
        {
            Console.WriteLine($"error: {e.Message}");
            base.OnError(e);
        }

        private void sendToAllExcept(string ID, String message)
        {
            foreach (var connection in Sessions.Sessions)
            {
                if (connection.ID != ID)
                {
                    Sessions.SendTo(message, connection.ID);
                }
            }
        }
    }
}
