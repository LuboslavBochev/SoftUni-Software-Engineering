namespace Bakery.Models.Drinks
{
    public class Tea : Drink
    {
        private const decimal teaPrice = 2.5M;

        public Tea(string name, int portion, string brand)
            : base(name, portion, teaPrice, brand)
        {
        }
    }
}
