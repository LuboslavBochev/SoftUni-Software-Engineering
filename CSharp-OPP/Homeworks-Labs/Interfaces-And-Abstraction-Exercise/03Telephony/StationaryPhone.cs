using System;

namespace Phone
{
    public class StationaryPhone : ICall
    {
        public string Calling(string number)
        {
            if (!Validator.IsNumberIsValid(number))
            {
                throw new InvalidOperationException(Validator.INVALID_NUMBER);
            }
            return $"Dialing... {number}";
        }
    }
}
