using System.Linq;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (var prop in properties)
            {
                MyValidationAttribute[] attributes = prop.GetCustomAttributes(true).Cast<MyValidationAttribute>().ToArray();

                var value = prop.GetValue(obj);

                foreach (var item in attributes)
                {
                    bool isValid = item.IsValid(value);

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
