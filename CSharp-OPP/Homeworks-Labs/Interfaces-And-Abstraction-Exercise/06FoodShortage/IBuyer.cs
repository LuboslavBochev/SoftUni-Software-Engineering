namespace FoodShortage
{
    public interface IBuyer
    {
        public string Name { get; }

        public void BuyFood();

        public int Food { get; }
    }
}
