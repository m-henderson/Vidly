using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Vidly.Models
{
    public class _1To20NumberOfMoviesInStock : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if (movie.NumberInStock < 20) return ValidationResult.Success;
            else return new ValidationResult("PLease enter a number lower than 20");
        }
    }
}