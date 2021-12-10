using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        private List<Player> list;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.list = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (this.Capacity != 0)
            {
                this.list.Add(player);
                this.Capacity--;
            }
        }

        public bool RemovePlayer(string name)
        {
            foreach (var player in this.list)
            {
                if (player.Name == name)
                {
                    this.list.Remove(player);
                    this.Capacity++;
                    return true;
                }
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            foreach (var player in this.list)
            {
                if (player.Name == name && player.Rank != "Member")
                {
                    player.Rank = "Member";
                    return;
                }
            }
        }

        public void DemotePlayer(string name)
        {
            foreach (var player in this.list)
            {
                if (player.Name == name && player.Rank != "Trial")
                {
                    player.Rank = "Trial";
                    return;
                }
            }
        }

        public Player[] KickPlayersByClass(string clas)
        {
            List<Player> kickedByClass = new List<Player>();

            List<Player> tempList = this.list.Select(x => x).ToList();

            foreach (var player in tempList)
            {
                if (player.Class == clas)
                {
                    this.list.Remove(player);
                    kickedByClass.Add(player);
                }
            }

            this.Capacity += kickedByClass.Count;

            return kickedByClass.ToArray();
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.list)
            {
                str.AppendLine(player.ToString());
            }
            return str.ToString().TrimEnd();
        }
    }
}
