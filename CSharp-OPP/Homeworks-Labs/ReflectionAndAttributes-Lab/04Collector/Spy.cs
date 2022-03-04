using System;
using System.Text;
using System.Reflection;
using System.Linq;

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
                |BindingFlags.Instance | BindingFlags.Static).Where(f => fieldsToInvestigate.Contains(f.Name)))
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

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder str = new StringBuilder();

            Type hackerType = Type.GetType("Stealer." + className);

            var publicFields = hackerType.GetFields(BindingFlags.Instance | BindingFlags.Public);

            var publicMethods = hackerType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            var privateMethods = hackerType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);


            foreach (var field in publicFields)
            {
                str.AppendLine($"{field.Name} must be private!");
            }

            foreach (var pcMethod in publicMethods.Where(m => m.Name.Contains("set")))
            {
                str.AppendLine($"{pcMethod.Name} have to be private!");
            }

            foreach (var ptMethod in privateMethods.Where(m => m.Name.Contains("get")))
            {
                str.AppendLine($"{ptMethod.Name} have to be public!");
            }

            return str.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder str = new StringBuilder();

            Type hackerType = Type.GetType(className);

            var privateMethods = hackerType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            str.AppendLine($"All Private Methods of Class: {hackerType.FullName}");
            str.AppendLine($"Base Class: {hackerType.BaseType.Name}");

            foreach (var prMethods in privateMethods)
            {
                str.AppendLine(prMethods.Name);
            }

            return str.ToString().TrimEnd();
        }
        public string CollectGettersAndSetters(string className)
        {
            StringBuilder str = new StringBuilder();

            Type hackerType = Type.GetType(className);

            var allMethods = hackerType.GetMethods(BindingFlags.Public | BindingFlags.Instance
                | BindingFlags.NonPublic);

            foreach (var method in allMethods)
            {
                if(method.Name.Contains("get"))
                {
                    str.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
                else if(method.Name.Contains("set")) // set
                {
                    str.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
                }
            }

            return str.ToString().TrimEnd();
        }
    }
}
