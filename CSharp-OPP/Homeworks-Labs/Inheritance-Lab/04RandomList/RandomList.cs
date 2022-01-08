using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private List<string> list;

        public RandomList(List<string> list)
        {
            this.list = list;
        }

        public string RandomString()
        {
            Random randomIndex = new Random();

            int rndToRemove = randomIndex.Next(0, this.list.Count - 1);

            this.list.RemoveAt(rndToRemove);

            return this.list[rndToRemove];
        }
    }
}
