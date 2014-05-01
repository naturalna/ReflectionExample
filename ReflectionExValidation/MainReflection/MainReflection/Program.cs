using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket;
using System.Reflection;

namespace MainReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IProduct> products = new List<IProduct>();
            Products product1 = new Products("tomatoes", 13);//faild validation on price
            Products product2 = new Products("potatoe", 5); // not faild validation
            Products product3 = new Products("name1", 1);//faild on validating name

            products.Add(product1);
            products.Add(product2);
            products.Add(product3);

            //load assembly
            Assembly assemblyWithRules =
                Assembly.LoadFrom(@"..\..\..\ExternalCLWithValidationRules\bin\Debug\ExternalCLWithValidationRules.dll");

            //see all types in it

            Type[] types = assemblyWithRules.GetTypes();

            List<IValidationRule> rules = new List<IValidationRule>();
            foreach (Type Type in types)
            {
                
                if (typeof(IValidationRule).IsAssignableFrom(Type) == true)
                {
                    var instance = Activator.CreateInstance(Type) as IValidationRule;
                    rules.Add(instance);
                }
            }

            foreach (IValidationRule rule in rules)
            {
                foreach (IProduct product in products)
                {
                   bool isFaild = rule.Validate(product);
                   if (isFaild)
                   {
                       Console.WriteLine(rule.Message);
                   }
                }
            }

        }
    }
}
