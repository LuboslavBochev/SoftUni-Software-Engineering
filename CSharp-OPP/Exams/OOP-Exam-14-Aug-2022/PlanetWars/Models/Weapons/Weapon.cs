﻿using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;

        protected Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }

        public double Price { get; private set; }

        public int DestructionLevel
        {
            get => this.destructionLevel;
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                if(value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                this.destructionLevel = value;
            }
        }
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
