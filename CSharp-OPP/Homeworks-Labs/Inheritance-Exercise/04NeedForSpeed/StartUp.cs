using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            FamilyCar sportCar = new FamilyCar(500, 200);

            sportCar.Drive(300);
        }
    }
}
