using System;

namespace Farm
{
    public abstract class Food
    {
        private string foodType;

        protected Food(int quantity, string foodType)
        {
            this.FoodType = foodType;
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }

        public string FoodType
        {
            get => this.foodType;
            private set
            {
                if (Enum.TryParse(value, out Foods food))
                {
                    this.foodType = food.ToString();
                }
            }
        }
    }
}
