using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    [TestFixture]
    public class Tests
    {
        private FootballPlayer footballPlayer;
        private FootballTeam footballTeam;

        [SetUp]
        public void Setup()
        {
            this.footballTeam = new FootballTeam("Man United", 21);
            this.footballPlayer = new FootballPlayer("Ronaldo", 11, "Forward");
        }

        [Test]
        public void constructurCreatedFootBallPlayer()
        {
            Assert.IsNotNull(this.footballPlayer);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void footballPlayerCannotBeNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException> (() => new FootballPlayer(name, 12, "Forward"));
        }

        [Test]
        [TestCase (0)]
        [TestCase(22)]
        public void footballPlayerShouldBeInRightRange(int playerNumber)
        {
            Assert.Throws<ArgumentException>(() => new FootballPlayer("roki", playerNumber, "Forward"));
        }

        [Test]
        public void positionShouldThrowExIfIsDif()
        {
            Assert.Throws<ArgumentException>(() => new FootballPlayer("baba", 5, "Diffrent"));
        }

        [Test]
        public void ScoreShouldIncrese()
        {
            int previousScore = this.footballPlayer.ScoredGoals;
            this.footballPlayer.Score();

            Assert.AreEqual(previousScore + 1, this.footballPlayer.ScoredGoals);
        }

        [Test]
        public void constructorOfFootBallTeamShouldCreate()
        {
            Assert.IsNotNull(this.footballTeam);
        }

        [Test]
        [TestCase ("")]
        [TestCase (null)]
        public void FootBallNameShouldThrowExIfIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam(name, 16));
        }

        [Test]
        public void CapacityShouldThrowExIfIsSmallerThanFitftheen()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("test", 2));
        }

        [Test]
        public void AddNewPlayerShouldThrowExIfNoSpace()
        {
            string expectedValue = "No more positions available!";

            FootballTeam testTeam = new FootballTeam("testTeam", 16);
            for (int i = 0; i < 16; i++)
            {
                testTeam.Players.Add(new FootballPlayer($"name{i}", 2 + i, "Midfielder"));
            }
            string actualValue = testTeam.AddNewPlayer(this.footballPlayer);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddNewPlayerShouldAddSuccesfully()
        {
            string expectedToReturn = $"Added player Ronaldo in position Forward with number 11";
            string actual = this.footballTeam.AddNewPlayer(this.footballPlayer);

            Assert.AreEqual(expectedToReturn, actual);
        }

        [Test]
        public void PickPlayerShouldReturnNullIfSuchNameDoesNotExist()
        {
            Assert.IsNull(this.footballTeam.PickPlayer("bab"));
        }

        [Test]
        public void PickPlayerShouldReturnRightPlayer()
        {
            var expectedName = new FootballPlayer("Bob", 11, "Forward");

            this.footballTeam.AddNewPlayer(new FootballPlayer("Bob", 11, "Forward"));

            Assert.AreEqual(expectedName.Name, this.footballTeam.PickPlayer("Bob").Name);
        }

        [Test]
        public void PlayerScoreShouldScore()
        {
            this.footballTeam.AddNewPlayer(this.footballPlayer);

            this.footballPlayer.Score();
            string expectedValue = $"{this.footballPlayer.Name} scored and now has {this.footballPlayer.ScoredGoals + 1} for this season!";

            Assert.AreEqual(expectedValue, this.footballTeam.PlayerScore(11));
        }
    }
}