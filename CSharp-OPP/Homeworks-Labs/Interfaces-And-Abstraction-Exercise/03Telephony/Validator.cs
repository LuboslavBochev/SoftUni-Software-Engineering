using System;
using System.Linq;

namespace Phone
{
    public static class Validator
    {
        public const string INVALID_NUMBER = "Invalid number!";

        public const string INVALID_URL = "Invalid URL!";

        public static bool IsNumberIsValid(string number) => number.All(Char.IsDigit);

        public static bool IsUrlIsValid(string url) => !url.Any(char.IsDigit);
    }
}
