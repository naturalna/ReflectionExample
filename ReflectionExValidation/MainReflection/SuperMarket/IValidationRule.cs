using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    public interface IValidationRule
    {
        string Message { get; set; }
        bool Validate(IProduct product);
    }
}
