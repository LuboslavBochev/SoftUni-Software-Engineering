using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel
        {
            get
            {
                return this.ingredients.Sum(alck => alck.Alcohol);
            }
        }

        public void Add(Ingredient ingredient)
        {
            if(this.MaxAlcoholLevel >= ingredient.Alcohol)
            {
                this.ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            foreach (var ingredient in this.ingredients)
            {
                if(ingredient.Name == name)
                {
                    this.ingredients.Remove(ingredient);
                    return true;
                }
            }
            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return this.ingredients.Find(ingredient => ingredient.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            int maxAlcohol = 0;
            object maxAlcoholicCoctail = new object();

            foreach (var ingredient in this.ingredients)
            {
                if(ingredient.Alcohol > maxAlcohol)
                {
                    maxAlcohol = ingredient.Alcohol;
                    maxAlcoholicCoctail = ingredient;
                }
            }
            return maxAlcoholicCoctail as Ingredient;
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (var coctail in this.ingredients)
            {
                report.AppendLine(coctail.ToString());
            }

            return report.ToString().TrimEnd();
        }
    }
}
