// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
   // using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private Performer performer;
		private Song song;
		private Stage stage;

		[SetUp]
		public void SetUp()
		{
			this.performer = new Performer("John", "Coner", 32);
			this.song = new Song("Yeye", TimeSpan.FromMinutes(2));
			this.stage = new Stage();
		}

		[Test]
	    public void ctor_CreateSuccessful()
	    {
			Assert.IsNotNull(this.stage);
			Assert.AreEqual(0, this.stage.Performers.Count);
		}
		[Test]
		public void AddPerformer_ThrowsExceptionIfPerformerDoesNotExist()
		{
			Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(null));
		}
		[Test]
		public void AddPerformer_ThrowsExceptionIfPerformerIsLessThanEighteen()
		{
			Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(new Performer("Body", "Kko", 15)));
		}
		[Test]
		public void AddPerformer_AddingPerformerSuccessfully()
		{
			this.stage.AddPerformer(this.performer);
			Assert.AreEqual(1, this.stage.Performers.Count);
		}
		[Test]
		public void AddSong_ThrowsExceptionIfSongIsNull()
		{
			Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(null));
		}
		[Test]
		public void AddSong_ThrowsExceptionIfSondDurationIsLessThanMinute()
		{
			Assert.Throws<ArgumentException>(() => this.stage.AddSong(new Song("Yeye", TimeSpan.FromMinutes(0.5))));
		}
		[Test]
		public void AddSong_AddingSuccessfully()
		{
			this.stage.AddSong(this.song);
			this.stage.AddPerformer(this.performer);
			this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);
			Assert.IsTrue(this.performer.SongList.Contains(this.song));
		}
		[Test]
		[TestCase(null, "John")]
		[TestCase("yaa", null)]
		public void AddSongToPerformer_ThrowsExceptionifPerformerIsNull(string songName, string performer)
		{
			Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(songName, performer));
		}
		[Test]
		[TestCase("Jony", "Yaya")] // moje i da trqbwa da gi razdelish na dva testa
		public void AddSongToPerformer_ThrowsExceptionEitherPerformerOrSongDoesNotExist(string songName, string performerName)
		{
			Assert.Throws<ArgumentException>(() => this.stage.AddSongToPerformer(songName, performerName));
		}
		[Test]
		public void AddSongToPerformer_ShouldAddSongCorrectly()
		{
			this.stage.AddSong(this.song);
			this.stage.AddPerformer(this.performer);
			this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);

			Assert.IsTrue(this.performer.SongList.Contains(this.song));
		}
		[Test]
		public void AddSongToPerformer_ShouldToReturnProperMessage()
		{
			this.stage.AddSong(this.song);
			this.stage.AddPerformer(this.performer);
			string expected = $"{this.song} will be performed by {this.performer}";
			string actual = this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);
			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void Play_ShouldReturnProperMessage()
		{
			this.stage.AddPerformer(this.performer);
			this.stage.AddPerformer(new Performer("joji", "trifanov", 19));
			this.stage.AddSong(this.song);
			this.stage.AddSong(new Song("UAUA", TimeSpan.FromMinutes(4.5)));
			this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);
			this.stage.AddSongToPerformer("UAUA", "joji trifanov");
			string expected = $"{this.stage.Performers.Count} performers played {this.stage.Performers.Sum(p => p.SongList.Count())} songs";
			Assert.AreEqual(expected, this.stage.Play());
		}
	}
}