using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace View.validate
{
    class ValidateEmptyString : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string v = (string)value;
            if (v == null || v.Length == 0)
                return new ValidationResult(false, "value cannot be empty.");
            return ValidationResult.ValidResult;
        }
    }
}
