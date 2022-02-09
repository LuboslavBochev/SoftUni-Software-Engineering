using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team : IPurchasePlayers
    {
        private string teamName;
        private List<Player> players;

        public Team(string teamName)
        {
            this.TeamName = teamName;
            this.players = new List<Player>();
        }

        public string TeamName
        {
            get => this.teamName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.teamName = value;
            }
        }

        public double Rating
        {
            get
            {
                double sumRating = 0;
                foreach (var player in this.players)
                {
                    sumRating += Math.Round(player.OverallSkill(),0);
                }

                if (sumRating != 0)
                    return sumRating / this.players.Count;

                else return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void PurchasePlayer(string playerName, decimal cost)
        {
            throw new NotImplementedException();
        }

        public void RemovePlayer(string playerName)
        {
            Player player = this.players.FirstOrDefault(player => player.Name == playerName);

            if (player != null)
            {
                this.players.Remove(player);
            }
            else
            {
                throw new ArgumentException($"Player {playerName} is not in {this.TeamName} team.");
            }
        }
    }
}
