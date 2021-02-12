using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Final_Fund_Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            int count = int.Parse(Console.ReadLine());

            string pattern = @"(?<whole>(\@{1}\#{1,})(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])(\@{1}\#{1,}))";
            string patternGroup = @"\d";

            for (int i = 0; i < count; i++)
            {
                string barcode = Console.ReadLine();

                Match matchedBarcode = Regex.Match(barcode, pattern);

                if (matchedBarcode.Success)
                {
                    string groupNum = string.Empty;

                    MatchCollection foundDigits = Regex.Matches(barcode, patternGroup);

                    if (foundDigits.Count > 0)
                    {
                        foreach (Match item in foundDigits)
                        {
                            groupNum += item;
                        }
                    }
                    else
                    {
                        groupNum = "00";
                    }
                    Console.WriteLine($"Product group: {groupNum}");
                }

                else
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }
            }
        }
    }
}