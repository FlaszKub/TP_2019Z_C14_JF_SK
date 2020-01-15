using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace View.validate
{
    class ValidateNumberZero : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool flag;
            if (value == null)
            {
                return new ValidationResult(false, "Value cannot be null.");
            }
            else
            {
                flag = int.TryParse((string)value, out int tmp);
                if (!flag)
                {
                    return new ValidationResult(false, "Value must be integer number.");
                }
                if (tmp < 0)
                {
                    return new ValidationResult(false, "Value must be higher or equal 0.");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
