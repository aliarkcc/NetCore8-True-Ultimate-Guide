﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidations.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ModelValidations.Models
{
    public class Person : IValidatableObject
    {
        [Required(ErrorMessage = "{0} can't be empty or null!")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long!")]
        //[RegularExpression("^[A-Z-a-z .]$", ErrorMessage = "{0} should contain only alphabets, space and dot (.)")]
        public string? PersonName { get; set; }



        [Required(ErrorMessage = "{0} can't be empty or null!")]
        [Display(Name = "Email")]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //ErrorMessage = "{0} is not valid!")]
        [EmailAddress(ErrorMessage = "{0} is not valid!")]
        public string? Email { get; set; }


        [Phone(ErrorMessage = "{0} should contain 10 digits!")]
        public string? Phone { get; set; }




        [Required(ErrorMessage = "{0} can't be empty or null!")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "{0} 6 between 16 ")]
        [Display(Name = "Password")]
        public string? Password { get; set; }



        [Required(ErrorMessage = "{0} can't be empty or null!")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "{0} 6 between 16 ")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match!")]
        public string? ConfirmPassword { get; set; }




        [Range(0, 999.99, ErrorMessage = "{0} should be between ${1} and ${2} ")]
        [Display(Name = "Price")]
        public double? Price { get; set; }


        //[MinimumYearValidator(2004,ErrorMessage = "Date of Birth should not be newer Jan 01, {0}")]
        [MinimumYearValidator(2004)]
        [BindNever]
        public DateTime? DateOfBirth { get; set; }



        public DateTime? FromDate { get; set; }


        [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older than to equal 'To Date'")]
        public DateTime? ToDate { get; set; }


        public int? Age { get; set; }

        public List<string?> Tags { get; set; } = new List<string?>();

        public override string ToString()
        {
            return $"Person Object - Person Name:{PersonName}, Email:{Email}, Phone:{Phone}, Password:{Password}, ConfirmPassword:{ConfirmPassword}, Price: {Price}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!DateOfBirth.HasValue && !Age.HasValue)
            {
                yield return new ValidationResult("Either of Date of Birth or Age must be supplied!", new[] { nameof(Age), nameof(DateOfBirth) });
            }

        }
    }
}
