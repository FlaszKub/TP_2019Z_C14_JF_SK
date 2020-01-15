using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace View.validate
{
    class ValidateProductName : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = (string)value;
            if (input == null || input.Length == 0)
                return new ValidationResult(false, "Product Name cannot be empty.");
            return ValidationResult.ValidResult;
        }
    }
}
