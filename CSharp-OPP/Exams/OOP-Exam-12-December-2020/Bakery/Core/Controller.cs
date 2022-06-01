using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            switch (type)
            {
                case "Tea":
                    drink = new Tea(name, portion, brand);
                    break;
                case "Water":
                    drink = new Water(name, portion, brand);
                    break;
            }
            this.drinks.Add(drink);
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood = null;

            switch (type)
            {
                case "Bread":
                    bakedFood = new Bread(name, price);
                    break;
                case "Cake":
                    bakedFood = new Cake(name, price);
                    break;
            }
            this.bakedFoods.Add(bakedFood);
            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            switch (type)
            {
                case "InsideTable":
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case "OutsideTable":
                    table = new OutsideTable(tableNumber, capacity);
                    break;

                default:
                    return null;
            }
            this.tables.Add(table);
            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> notReservedTables = this.tables.Where(t => !t.IsReserved).ToList();

            StringBuilder str = new StringBuilder();

            foreach (var table in notReservedTables)
            {
                str.AppendLine(table.GetFreeTableInfo());
            }
            return str.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, this.totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if(table == null) return string.Format(OutputMessages.WrongTableNumber, tableNumber);

            decimal total = table.GetBill() + table.Price;
            this.totalIncome += total;
            this.totalIncome += table.Price;
            table.Clear();

            string result = $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {total:f2}";
            return result;
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null) return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            if (drink == null) return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood bakedFood = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null) return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            if (bakedFood == null) return string.Format(OutputMessages.NonExistentFood, foodName);

            table.OrderFood(bakedFood);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.Where(t => !(t.IsReserved) && t.Capacity >= numberOfPeople).FirstOrDefault();

            if(table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, table.TableNumber, table.NumberOfPeople);
        }
    }
}
