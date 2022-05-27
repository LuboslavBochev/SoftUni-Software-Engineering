using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity = 100;
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get => this.capacity; set => this.capacity = value; }

        public int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            int totalWeight = this.Load + item.Weight;

            if(totalWeight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            Item searchedItem = this.items.FirstOrDefault(i => i.GetType().Name == name);

            if(!this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            else if(searchedItem == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            this.items.Remove(searchedItem);
            return searchedItem;
        }
    }
}
