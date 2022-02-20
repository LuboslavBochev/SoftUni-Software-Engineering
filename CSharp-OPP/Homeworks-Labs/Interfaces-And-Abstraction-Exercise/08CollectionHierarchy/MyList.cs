using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {
        private List<string> elements;

        public MyList()
        {
            this.elements = new List<string>();
        }

        public int Used { get => this.elements.Count; }

        public int AddItem(string item)
        {
            this.elements.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string elementAtFirst = this.elements[0];
            this.elements.RemoveAt(0);

            return elementAtFirst;
        }
    }
}
