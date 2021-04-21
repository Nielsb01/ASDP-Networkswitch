/*
    AIM SD ASD 2020/2021 S2 project
     
    Project name: Networkswitch
 
    This file is created by team: 5
     
    Goal of this file: Class for Rooms in more advanced protoype
     
*/


using System.Collections.Generic;
using WebSocketSharp.Server;

namespace NetworkSwitch
{
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
            foreach (var id in connectionsIDs)
            {
                sessions.SendTo(message, id);
            }
        }
    }
}
