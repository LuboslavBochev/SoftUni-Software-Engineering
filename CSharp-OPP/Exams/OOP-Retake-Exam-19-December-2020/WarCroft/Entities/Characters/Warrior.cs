using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double baseHealth = 100;
        private const double baseArmor = 50;
        private const double abilityPoints = 40;

        public Warrior(string name)
            : base(name, baseHealth, baseArmor, abilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            base.EnsureAlive();
            character.EnsureAlive();

            if(this.Equals(character))
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            if (this.AbilityPoints > character.Armor)
            {
                double dif = this.AbilityPoints - character.Armor;

                character.Armor -= this.AbilityPoints;
                character.Health -= dif;

                if (character.Health == 0) character.IsAlive = false;
            }
            else
            {
                character.Armor -= this.AbilityPoints;
            }
        }
    }
}
