using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DarkKnight darkKinight = new DarkKnight("Lich King", 120);
            Console.WriteLine(darkKinight);
        }
    }
}