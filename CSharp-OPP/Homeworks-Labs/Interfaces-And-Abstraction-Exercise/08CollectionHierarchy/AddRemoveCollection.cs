using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> elements;

        public AddRemoveCollection()
        {
            this.elements = new List<string>();
        }

        public int AddItem(string item)
        {
            this.elements.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            int lastIndex = this.elements.Count;

            string item = this.elements[lastIndex - 1];

            this.elements.RemoveAt(lastIndex - 1);
            return item;
        }
    }
}
