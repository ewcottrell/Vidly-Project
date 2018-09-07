using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18yearsIfAMember : ValidationAttribute
    {

        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    var customer = (CustomerViewModel)validationContext.ObjectInstance;
        //    var age = DateTime.Today.Year - customer.Birthdate.Year;
        //    return (age >= 18) ? 
        //        ValidationResult.Success : new ValidationResult
        //                          ("Customer must be at least 18 years old to become a member");
        //}

    }
}
