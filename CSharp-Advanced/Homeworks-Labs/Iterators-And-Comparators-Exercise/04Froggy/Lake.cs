using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Lake : IEnumerable<int>
    {
        private List<int> numbers;

        public Lake(List<int> numbers)
        {
            this.numbers = new List<int>(numbers);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.numbers.Count; i += 2)
            {
                yield return this.numbers[i];
            }

            int lastIndex = this.numbers.Count % 2 == 0 ? this.numbers.Count - 1 : this.numbers.Count - 2;

            for (int i = lastIndex; i >= 0; i -= 2)
            {
                yield return this.numbers[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
