using System;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string clas)
        {
            this.Name = name;
            this.Class = clas;
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public string Name { get; private set; }

        public string Class { get; private set; }

        public string Rank { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"Player {Name}: {Class}" + Environment.NewLine +
                   $"Rank: {this.Rank}" + Environment.NewLine +
                   $"Description: {this.Description}";
        }
    }
}
