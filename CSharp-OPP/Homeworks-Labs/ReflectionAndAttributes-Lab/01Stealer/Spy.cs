using System;
using System.Text;
using System.Reflection;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            StringBuilder str = new StringBuilder();

            Type hackerType = Type.GetType(classToInvestigate);

            str.AppendLine($"Class under investigation: {hackerType.FullName}");

            var instance = Activator.CreateInstance(hackerType);

            foreach (var field in hackerType.GetFields(BindingFlags.Public | BindingFlags.NonPublic
                |BindingFlags.Instance | BindingFlags.Static))
            {
                if(field.Name == "username")
                {
                    str.AppendLine($"username = {field.GetValue(instance)}");
                }

                if(field.Name == "password")
                {
                    str.AppendLine($"password = {field.GetValue(instance)}");
                }
            }

            return str.ToString().TrimEnd();
        }
    }
}
