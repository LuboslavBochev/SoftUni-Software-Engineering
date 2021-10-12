using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsExercise
{
    public class Box<T>
    {
        public Box(List<T> items)
        {
            this.Items = items;
        }

        public List<T> Items { get; set; }

        public void Swap(int indexOne, int indexTwo)
        {
            T firstStr = Items[indexOne];

            Items[indexOne] = Items[indexTwo];
            Items[indexTwo] = firstStr;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            foreach (var item in this.Items)
            {
                str.AppendLine($"{item.GetType()}: {item}");
            }
            return str.ToString().TrimEnd();
        }
    }
}
