using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Enumerable = System.Linq.Enumerable;

namespace Guild
{
    public class Guild
    {
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = new List<Player>();
        }

        List<Player> Roster = new List<Player>();
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get => Roster.Count;
        }

        public void AddPlayer(Player player)
        {
            if (Roster.Count < Capacity)
            {
                Roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player playerToRemove = Roster.Find(x => x.Name == name);
            return Roster.Remove(playerToRemove);
        }

        public void PromotePlayer(string name)
        {
            Player playerToPromote = Roster.FirstOrDefault(x => x.Name == name);
            if (playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player playerToDemote = Roster.FirstOrDefault(x => x.Name == name);
            if (playerToDemote.Rank != "Trial")
            {
                playerToDemote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classToKick)
        {
            Player[] kickedPlayers = Roster.FindAll(x => x.Class == classToKick).ToArray();
            Roster.RemoveAll(x => x.Class == classToKick);
            return kickedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (Player player in Roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }


    }
}
