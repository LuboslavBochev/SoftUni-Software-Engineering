using System;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            int countStudents = int.Parse(Console.ReadLine());
            int countLectures = int.Parse(Console.ReadLine());

            int additionalBonus = int.Parse(Console.ReadLine());

            double totalBonus = 0.0;
            double maxBonus = 0.0;
            int maxBonusLectures = 0;

            for (int i = 0; i < countStudents; i++)
            {

                int attendanceOfStudent = int.Parse(Console.ReadLine());

                totalBonus = 1.0 * attendanceOfStudent / countLectures * (5 + additionalBonus);

                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    maxBonusLectures = attendanceOfStudent;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Round(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxBonusLectures} lectures.");
        }
    }
}