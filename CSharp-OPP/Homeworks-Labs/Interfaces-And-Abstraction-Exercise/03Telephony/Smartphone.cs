using System;

namespace Phone
{
    public class Smartphone : IBrowse, ICall
    {
        public string Browsing(string urlAddress)
        {
            if (!Validator.IsUrlIsValid(urlAddress))
            {
                throw new InvalidOperationException(Validator.INVALID_URL);
            }
            return $"Browsing: {urlAddress}!";
        }

        public string Calling(string number)
        {
            if (!Validator.IsNumberIsValid(number))
            {
                throw new InvalidOperationException(Validator.INVALID_NUMBER);
            }
            return $"Calling... {number}";
        }
    }
}
