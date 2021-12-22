using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            this.Name = name;
            this.Alcohol = alcohol;
            this.Quantity = quantity;
        }

        public string Name { get; set; }

        public int Alcohol { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Ingredient: {this.Name}");
            result.AppendLine($"Quantity: {this.Quantity}");
            result.AppendLine($"Alcohol: {this.Alcohol}");
            return result.ToString().TrimEnd();
        }
    }
}
