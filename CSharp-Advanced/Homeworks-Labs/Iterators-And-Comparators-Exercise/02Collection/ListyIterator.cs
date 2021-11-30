using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int currentIndex;

        public ListyIterator(params T[] elements)
        {
            this.elements = new List<T>(elements);
        }

        public bool Move()
        {
            if (currentIndex + 1 < elements.Count)
            {
                currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return currentIndex + 1 < elements.Count;
        }

        public void Print()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(elements[currentIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in elements)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
