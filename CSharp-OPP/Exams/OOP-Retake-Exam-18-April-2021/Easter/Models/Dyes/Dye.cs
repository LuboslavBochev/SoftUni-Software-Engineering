using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this.power;
            private set
            {
                this.power = value < 0 ? 0 : value;
            }
        }

        public bool IsFinished()
        {
            if (this.Power == 0) return true;
            else return false;
        }

        public void Use()
        {
            this.Power = this.Power - 10 < 0 ? 0 : this.Power - 10;
        }
    }
}
