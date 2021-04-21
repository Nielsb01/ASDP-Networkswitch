/*
    AIM SD ASD 2020/2021 S2 project
     
    Project name: Networkswitch
 
    This file is created by team: 5
     
    Goal of this file: more advanced behavior for networkswitch
     
*/

using System;
using System.Collections.Generic;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace NetworkSwitch
{
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
                if (rooms.Find(x => x.GetName() == roomName) != null)
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
                if (foundRoom == null)
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
            if (e.Data == "show rooms")
            {
                if (rooms.Count == 0)
                {
                    Send("No rooms created");
                }
                else
                {
                    foreach (Room room in rooms)
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
}
