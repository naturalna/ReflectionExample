using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket;

namespace ExternalCLWithValidationRules
{
   public class NameRule : IValidationRule
    {
        public bool Validate(IProduct product)
        {
            if (product.Name == "name1")
            {
                this.Message = "The name is wrong: "+ product.Name;
                return true;
            }

            return false;
        }

        private string message;
        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }
    }
}
