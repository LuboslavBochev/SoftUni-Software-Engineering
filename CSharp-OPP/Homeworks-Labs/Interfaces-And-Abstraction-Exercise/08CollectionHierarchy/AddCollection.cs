using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        private List<string> elements;

        public AddCollection()
        {
            elements = new List<string>();
        }

        public int AddItem(string item)
        {
            int endIndex = this.elements.Count;
            this.elements.Insert(endIndex, item);

            return endIndex;
        }
    }
}
