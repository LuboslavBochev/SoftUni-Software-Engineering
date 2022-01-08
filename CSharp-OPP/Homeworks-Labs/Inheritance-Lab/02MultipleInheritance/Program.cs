using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Puppy john = new Puppy();

            john.Eat();
            john.Bark();
            john.Weep();
        }
    }
}
