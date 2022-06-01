namespace Bakery.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal waterPrice = 1.5M;
        public Water(string name, int portion, string brand)
            : base(name, portion, waterPrice, brand)
        {
        }
    }
}
