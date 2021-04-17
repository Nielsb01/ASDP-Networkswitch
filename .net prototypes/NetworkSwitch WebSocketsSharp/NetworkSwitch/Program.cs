﻿/*
    AIM SD ASD 2020/2021 S2 project
     
    Project name: Networkswitch
 
    This file is created by group 5 Wim Beukers
     
    Goal of this file: prototype for networkswitch using WebSocketSharp
     
*/


using WebSocketSharp;
using WebSocketSharp.Server;
using System;
using System.Collections.Generic;

namespace NetworkSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Room> rooms = new List<Room>();

            WebSocketServer wss = new WebSocketServer("ws://localhost:8088");
            wss.AddWebSocketService<EchoRoom>("/Echo", () => new EchoRoom(rooms));
            wss.AddWebSocketService<Relay>("/Relay");


            wss.Start();
            Console.WriteLine("started on port 8088");
            Console.ReadKey();
            wss.Stop();
        }
    }

    // dumb switch prototype
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
            Console.WriteLine($"message received: {e.Data}");
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
            foreach(var connection in Sessions.Sessions)
            {
                if(connection.ID != ID)
                {
                    Sessions.SendTo(message, connection.ID);
                }
            }
        }
    }


    // smarter switch prototype
    public class EchoRoom : WebSocketBehavior
    {
        private Room room;
        private List<Room> rooms;

        public EchoRoom(List<Room> rooms)
        {
            this.rooms = rooms;
        }

        protected override void OnOpen()
        {
            Console.WriteLine("connection opened");
            base.OnOpen();
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            // check for room commands
            if (e.Data.Contains("create room "))
            {
                var roomName = e.Data.Replace("create room ", "");
                if(rooms.Find(x => x.GetName() == roomName) != null)
                {
                    Send("room already exists");
                }
                else
                {
                    if (room != null)
                    {
                        room.DeleteFromRoom(ID);
                    }
                    room = new Room(roomName, ID);
                    rooms.Add(room);
                }
            }
            else if (e.Data.Contains("join room "))
            {
                var roomName = e.Data.Replace("join room ", "");
                Room foundRoom = rooms.Find(x => x.GetName() == roomName);
                if(foundRoom == null)
                {
                    Send("room not found");
                }
                else
                {
                    if (room != null)
                    {
                        room.DeleteFromRoom(ID);
                    }
                    foundRoom.AddToRoom(ID);
                    room = foundRoom;
                }
            }


            // send message
            if(e.Data == "show rooms")
            {
                if(rooms.Count == 0)
                {
                    Send("No rooms created");
                }
                else
                {
                    foreach(Room room in rooms)
                    {
                        Send($"room {room.GetName()} has {room.GetSumOfConnections()}/8 participants.");
                    }
                }
            }
            else if (room == null)
            {
                Send(e.Data);
            }
            else
            {
                room.SendToRoom(e.Data, Sessions);
            }

            Console.WriteLine($"you're in room {room?.GetName()}");
            base.OnMessage(e);
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Console.WriteLine("connection closed");
            base.OnClose(e);
        }
    }

    public class Room
    {
        private List<string> connectionsIDs;
        private string name;

        public Room(string name, string hostId)
        {
            connectionsIDs = new List<string>();
            connectionsIDs.Add(hostId);
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public int GetSumOfConnections()
        {
            return connectionsIDs.Count;
        }

        public void AddToRoom(string ID)
        {
            connectionsIDs.Add(ID);
        }

        public void DeleteFromRoom(string ID)
        {
            connectionsIDs.Remove(ID);
        }

        public void SendToRoom(string message, WebSocketSessionManager sessions)
        {
            foreach(var id in connectionsIDs)
            {
                sessions.SendTo(message, id);
            }
        }
    }
}