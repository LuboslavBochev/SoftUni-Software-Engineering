using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class DateModifier
    {
        public int GetDays(string firstDate, string seconDate)
        {
            int[] firstDateDetails = firstDate.Split(" ").Select(int.Parse).ToArray();

            DateTime first = new DateTime(firstDateDetails[0], firstDateDetails[1], firstDateDetails[2]);

            int[] secondDateDetails = seconDate.Split(" ").Select(int.Parse).ToArray();

            DateTime second = new DateTime(secondDateDetails[0], secondDateDetails[1], secondDateDetails[2]);

            return Math.Abs((first - second).Days);
        }
    }
}
