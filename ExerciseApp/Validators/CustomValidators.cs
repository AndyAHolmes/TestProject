using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ExerciseApp.Validators
{
    /// <summary>
    /// Class <c>CustomValidation</c> inherit ValidationAttribute to create custom attribute validation; Simply add annotation on the related model attribute for validation; It is not use in the moment;
    /// </summary>
    public class CustomValidation
    {
        public sealed class checkDateOfBirth : ValidationAttribute
        {
            protected override ValidationResult IsValid(object dateOfBirth, ValidationContext validationContext)
            {

                if (DateTime.Now.Year - ((DateTime)dateOfBirth).Year > 17 && DateTime.Now.Year - ((DateTime)dateOfBirth).Year <= 80)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("People under the age of 17 and over the age of 80 can not receive a quote");
                }
            }
        }
    }
}


