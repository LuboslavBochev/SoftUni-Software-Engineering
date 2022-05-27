using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private double health;
		private double armor;

		protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
		{
			this.Name = name;
			this.BaseHealth = health;
			this.Health = health;
			this.BaseArmor = armor;
			this.Armor = armor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;
			this.IsAlive = true;
		}

		public string Name
		{
			get => this.name;
			private set
			{
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
				}
				this.name = value;
			}
		}

		public bool IsAlive { get; set; }

		public double BaseHealth { get; private set; }

		public double Health
		{
			get => this.health;
			set
			{
				if (value > this.BaseHealth)
				{
					this.health = this.BaseHealth;
				}
				else if (value < 0)
				{
					this.health = 0;
				}
				else this.health = value;
			}
		}

		public double BaseArmor { get; private set; }

		public double Armor
		{
			get => this.armor;
			set
			{
				if (value < 0)
				{
					this.armor = 0;
				}
				else this.armor = value;
			}
		}

		public double AbilityPoints { get; private set; }

		public Bag Bag { get; private set; }

		public void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public void TakeDamage(double hitPoints)
		{
			EnsureAlive();

		    if(hitPoints > this.Armor)
			{
				double dif = hitPoints - this.Armor;

				this.Armor -= hitPoints;
				this.Health -= dif;
			}
			else
			{
				this.Armor -= hitPoints;
			}
		}

		public void UseItem(Item item)
		{
			EnsureAlive();

			item.AffectCharacter(this);
		}
	}
}