using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mygavolt.ValidationRules
{
    class NotNullOrEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (String.IsNullOrEmpty(value as String))
            {
                return new ValidationResult(false, "Le champ doit être remplit.");
            }
            return new ValidationResult(true, String.Empty);
        }
    }
}
