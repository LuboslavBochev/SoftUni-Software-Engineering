using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        this.hero = new Hero("John", 10);
        this.heroRepository = new HeroRepository();
    }

    [Test]
    public void ctor_CreatingSuccessfully()
    {
        Assert.IsNotNull(this.heroRepository);
        Assert.AreEqual(this.heroRepository.Heroes.Count, 0);
    }

    [Test]
    public void Create_ShouldThrowExceptionIfHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Create(null));
    }

    [Test]
    public void Create_ShouldThrowExceptionIfHeroAlreadyExists()
    {
        this.heroRepository.Create(this.hero);
        Assert.Throws<InvalidOperationException>(() => this.heroRepository.Create(this.hero));
    }

    [Test]
    public void Create_ShouldCreateHeroSuccessfully()
    {
        this.heroRepository.Create(this.hero);
        Assert.AreEqual(this.heroRepository.Heroes.Count, 1);
    }

    [Test]
    [TestCase(" ")]
    [TestCase(null)]
    public void Remove_ShouldThrowExceptionIfNameIsNullOrWhitespace(string name)
    {
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(name));
    }

    [Test]
    public void Remove_ShouldReturnFalseIfHeroDoesNotExist()
    {
        Assert.IsFalse(this.heroRepository.Remove("Mike"));
    }

    [Test]
    public void Remove_ShouldRemoveHero()
    {
        this.heroRepository.Create(this.hero);

        int expectedCount = 0;

        Assert.IsTrue(this.heroRepository.Remove(this.hero.Name));
        Assert.AreEqual(this.heroRepository.Heroes.Count, expectedCount);
    }

    [Test]
    public void GetHeroWithHighestLevel_ShouldReturnHeroWithHighestLevel()
    {
        this.CreatingHeroes();

        int maxExpectedLevel = 11;

        Hero actualHero = this.heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(actualHero.Level, maxExpectedLevel);
    }

    [Test]
    public void GetHero_ShouldReturnHero()
    {
        this.heroRepository.Create(this.hero);

        string expectedName = this.hero.Name;

        Hero actualHero = this.heroRepository.GetHero(this.hero.Name);

        Assert.AreEqual(actualHero.Name, expectedName);
    }

    [Test]
    public void GetHero_ShouldReturnNullIfHeroDoesNotExist()
    {
        Assert.IsNull(this.heroRepository.GetHero("bla"));
    }

    [Test]
    public void Heroes_ShouldReturnCollection()
    {
        List<Hero> expectedHeroes = new List<Hero>();
        this.CreatingHeroes();

        for (int i = 0; i < 10; i++)
        {
            Hero hero = new Hero($"A{i}", i + 2);
            expectedHeroes.Add(hero);
        }

        Assert.AreEqual(this.heroRepository.Heroes.Count, expectedHeroes.Count);
    }

    private void CreatingHeroes()
    {
        for (int i = 0; i < 10; i++)
        {
            this.heroRepository.Create(new Hero($"A{i}", i + 2));
        }
    }
}