using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class ListyIterator<T>
    {
        private T[] collection;
        private int index;

        public ListyIterator(T[] collection)
        {
            this.collection = collection;
            this.index = 0;
        }

        public bool Move()
        {
            if (this.index < this.collection.Length - 1)
            {
                this.index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return this.index < this.collection.Length - 1 ? true : false;
        }

        public void Print()
        {
            if (this.collection.Length != 0)
            {
                Console.WriteLine(this.collection[this.index]);
                return;
            }
            throw new InvalidOperationException("Invalid Operation!");
        }

        //public IEnumerator<T> GetEnumerator()
        //{
        //    foreach (var item in this.collection)
        //    {
        //        yield return item;
        //    }
        //}

        //IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
