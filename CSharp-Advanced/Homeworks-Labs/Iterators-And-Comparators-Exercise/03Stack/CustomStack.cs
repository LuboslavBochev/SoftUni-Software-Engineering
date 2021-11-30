using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private int counter = 0;
        public Node<T> Head { get; set; }

        public void Push(T[] array)
        {
            if (Head == null)
            {
                Head = new Node<T>(array[0]);

                foreach (var element in array.Skip(1))
                {
                    Node<T> newHead = new Node<T>(element);

                    Head.Next = newHead;
                    newHead.Previous = Head;
                    Head = newHead;
                }
                counter = array.Length;
            }
            else
            {
                foreach (var element in array)
                {
                    Node<T> newHead = new Node<T>(element);

                    Head.Next = newHead;
                    newHead.Previous = Head;
                    Head = newHead;
                }
            }
        }

        public void Pop()
        {
            if(Head != null)
            {
                Head = Head.Previous;
                this.counter--;
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentHead = Head;

            while(currentHead != null)
            {
                T value = currentHead.Value;

                currentHead = currentHead.Previous;

                yield return value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
