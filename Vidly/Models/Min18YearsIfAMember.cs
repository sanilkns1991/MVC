using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipId == MembershipType.Unknown || customer.MembershipId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.BirtDate == null)
                return new ValidationResult("Birth date required");
            var age = DateTime.Today.Year - customer.BirtDate.Value.Year;
            return (age > 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer Should be atleast 18 years old to go for a membership.");
        }
    }
}