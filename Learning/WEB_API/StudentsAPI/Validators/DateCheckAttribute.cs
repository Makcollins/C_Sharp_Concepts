using System;
using System.ComponentModel.DataAnnotations;

namespace StudentsAPI.Validators;

public class DateCheckAttribute : ValidationAttribute
{
    //inherit IsValid method from Validation Attribute class 
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        //convert the type of value from object to DateTime
        var date = (DateTime?)value;

        if (date < DateTime.Now)
        {
            return new ValidationResult("The date must be greater than or equal todays date");
        }
        return ValidationResult.Success; 
    }
}
