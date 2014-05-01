using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket;

namespace ExternalCLWithValidationRules
{
    public class PriceRule : IValidationRule
    {
        public bool Validate(IProduct product)
        {
            if (product.Price > 10)
            {
                this.Message = "Price is more then 10 : "+ product.Name;
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
