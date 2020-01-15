using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace View.validate
{
    class ValidateProductNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = (string)value;
            if (input.Length != 7)
            {
                return new ValidationResult(false, "Value must have 7 characters");
            }

            if (input[2] == '-' && Char.IsLetter(input[0]) && Char.IsLetter(input[1]) && Char.IsDigit(input[3]) && Char.IsDigit(input[4])
                && Char.IsDigit(input[5]) && Char.IsDigit(input[6]))
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Value does not match schema LL-NNNN");
        }
    }
}
