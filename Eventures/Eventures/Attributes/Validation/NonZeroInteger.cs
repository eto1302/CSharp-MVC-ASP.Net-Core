using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Attributes.Validation
{
    public class NonZeroInteger : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((int)value == 0) return new ValidationResult("Number of tickets should be a non-zero integer.");
            return ValidationResult.Success;
        }

    }
}
