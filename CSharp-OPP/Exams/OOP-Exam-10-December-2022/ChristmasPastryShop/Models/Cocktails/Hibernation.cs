namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        const double LargeMulledWine = 10.50;

        public Hibernation(string cocktailName, string size)
            : base(cocktailName, size, LargeMulledWine)
        {
        }
    }
}
