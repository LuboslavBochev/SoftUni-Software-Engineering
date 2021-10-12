using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsExercise
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            var type = this.Value.GetType();

            str.Append($"{type.FullName}: ");
            str.Append(this.Value);

            return str.ToString();
        }
    }
}
