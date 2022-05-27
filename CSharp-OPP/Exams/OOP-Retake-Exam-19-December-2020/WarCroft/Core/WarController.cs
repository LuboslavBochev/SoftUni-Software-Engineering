using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> characterParty;
        private readonly List<Item> itemPool;

        public WarController()
        {
            this.characterParty = new List<Character>();
            this.itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            Character character;
            string characterType = args[0];
            string name = args[1];

            if (characterType == "Priest")
            {
                character = new Priest(name);
            }
            else if (characterType == "Warrior")
            {
                character = new Warrior(name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
            this.characterParty.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            Item item;
            string itemName = args[0];

            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }
            this.itemPool.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = this.characterParty.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (!this.itemPool.Any())
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
            }
            Item item = this.itemPool.Last();

            character.Bag.AddItem(item);
            this.itemPool.Remove(item);
            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.characterParty.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            Item item = character.Bag.GetItem(itemName);
            item.AffectCharacter(character);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder str = new StringBuilder();
            foreach (var character in this.characterParty.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                string isAlive = character.IsAlive ? "Alive" : "Dead";
                str.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {isAlive}");
            }
            return str.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.characterParty.FirstOrDefault(c => c.Name == attackerName);
            Character reciver = this.characterParty.FirstOrDefault(c => c.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (reciver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            ((IAttacker)attacker).Attack(reciver);
            bool isAlive = reciver.Health == 0 ? false : true;

            if (!isAlive)
            {
                string result = string.Format(SuccessMessages.AttackCharacter, attacker.Name, reciver.Name, attacker.AbilityPoints,
                reciver.Name, reciver.Health, reciver.BaseHealth, reciver.Armor, reciver.BaseArmor);
                result += Environment.NewLine + string.Format(SuccessMessages.AttackKillsCharacter, reciver.Name);
                return result.TrimEnd();
            }
            return string.Format(SuccessMessages.AttackCharacter, attacker.Name, reciver.Name, attacker.AbilityPoints,
                reciver.Name, reciver.Health, reciver.BaseHealth, reciver.Armor, reciver.BaseArmor);
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReciverName = args[1];

            Character healer = this.characterParty.FirstOrDefault(c => c.Name == healerName);
            Character reciver = this.characterParty.FirstOrDefault(c => c.Name == healingReciverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (reciver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReciverName));
            }

            if(healer.GetType().Name != "Priest")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            ((IHealer)healer).Heal(reciver);
            return string.Format(SuccessMessages.HealCharacter, healerName, reciver.Name, healer.AbilityPoints, reciver.Name, reciver.Health);
        }
    }
}
