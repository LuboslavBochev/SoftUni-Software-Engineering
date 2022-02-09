using System;

namespace PizzaEncapsulation
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                var type = value.ToLower();
                if(type != "white" && type != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                else
                {
                    this.flourType = type;
                }
            }
        }

        private string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                var technique = value.ToLower();
                if (technique != "crispy" && technique != "chewy" && technique != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                else
                {
                    this.bakingTechnique = technique;
                }
            }
        }

        private double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if(value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                else
                {
                    this.weight = value;
                }
            }
        }
        public double CalculateCalories()
        {
            double modifierFlour = 0;
            double modifierTechnique = 0;

            if (this.FlourType == "white")
            {
                modifierFlour = 1.5;
            }
            if (this.FlourType == "wholegrain")
            {
                modifierFlour = 1.0;
            }
            if (this.BakingTechnique == "crispy")
            {
                modifierTechnique = 0.9;
            }
            if (this.BakingTechnique == "chewy")
            {
                modifierTechnique = 1.1;
            }
            if (this.BakingTechnique == "homemade")
            {
                modifierTechnique = 1.0;
            }

            return (2 * this.Weight) * modifierFlour * modifierTechnique;
        }
    }
}
