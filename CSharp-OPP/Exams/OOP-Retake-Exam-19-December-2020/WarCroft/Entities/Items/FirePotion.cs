﻿using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int weight = 5;

        public FirePotion()
            : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            character.Health -= 20;

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
