using System;

namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int maxCapacity = 15;

        public BoxingGym(string name)
            : base(name, maxCapacity)
        {
        }
    }
}
