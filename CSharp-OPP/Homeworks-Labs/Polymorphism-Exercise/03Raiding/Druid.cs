using System;

namespace Raid
{
    public class Druid : BaseHero
    {
        private const int power = 80;

        public Druid(string name)
            : base(name, power)
        {

        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
