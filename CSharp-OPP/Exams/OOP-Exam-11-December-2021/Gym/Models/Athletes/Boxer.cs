using System;
using Gym.Utilities.Messages;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int initialStamina = 60;

        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, initialStamina)
        {
        }
        //Can train only in a BoxingGym
        public override void Exercise()
        {
            int increasedStamina = this.Stamina + 15;

            if(increasedStamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
            this.Stamina += 15;
        }
    }
}
