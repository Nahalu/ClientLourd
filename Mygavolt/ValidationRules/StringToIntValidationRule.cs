﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mygavolt.ValidationRules
{
    class StringToIntValidationRule : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int i;
            if (int.TryParse(value.ToString(), out i))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "La valeur doit être un chiffre.");
        }
    }
}