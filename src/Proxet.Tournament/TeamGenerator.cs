using System;
using System.Collections.Generic;
using System.IO;

namespace Proxet.Tournament
{
    public class TeamGenerator
    {
        public (string[] team1, string[] team2) GenerateTeams(string filePath)
        {
            var PlayerQueue = GetPlayerQueue(filePath);//Creating player queue
            return (GetTeam(PlayerQueue), GetTeam(PlayerQueue));//return 2 teams )
        }
        private List<Player> GetPlayerQueue(string filePath)//Reading from file to get queue
        {
            bool startFile = false;
            var fileData = new List<string>();
            var PlayerQueue = new List<Player>();
            using (StreamReader sr = File.OpenText(filePath))
            {
                string line = String.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    if (startFile)
                    {
                        string[] stat = line.Split('\t');
                        PlayerQueue.Add(new Player(stat[0], int.Parse(stat[1]), int.Parse(stat[2])));
                    }
                    if (line == "UserName	WaitTimeSec	VehicleClass") startFile = true;
                }
                PlayerQueue.Sort((a, b) => b.WaitTimeSec.CompareTo(a.WaitTimeSec));//QuickSort the queue
            }
            return PlayerQueue;
        }
        private string[] GetTeam(List<Player> playersQueue)//Team building
        {
            string[] team = new string[9];
            int teamIndex = 0;
            int vehicleIndexType1 = 0;
            int vehicleIndexType2 = 0;
            int vehicleIndexType3 = 0;
            for (int i = 0; i < playersQueue.Count; i++)
            {
                switch (playersQueue[i].VehicleType)
                {
                    case 1:
                        if (vehicleIndexType1 < 3 && teamIndex <= 9)//Adding to a team player with vehicle type 1
                        {
                            team[teamIndex] = playersQueue[i].Name;
                            teamIndex++;
                            vehicleIndexType1++;
                            playersQueue.RemoveAt(i);//if a player is added to the team, he will be removed from the queue
                            i = 0;
                        }
                        break;
                    case 2:
                        if (vehicleIndexType2 < 3 && teamIndex <= 9)//Adding to a team player with vehicle type 2
                        {
                            team[teamIndex] = playersQueue[i].Name;
                            teamIndex++;
                            vehicleIndexType2++;
                            playersQueue.RemoveAt(i);//if a player is added to the team, he will be removed from the queue
                            i = 0;
                        }
                        break;
                    case 3:
                        if (vehicleIndexType3 < 3 && teamIndex <= 9)//Adding to a team player with vehicle type 3
                        {
                            team[teamIndex] = playersQueue[i].Name;
                            teamIndex++;
                            vehicleIndexType3++;
                            playersQueue.RemoveAt(i);//if a player is added to the team, he will be removed from the queue
                            i = 0;
                        }
                        break;
                }
            }
            return team;
        }
    }
}