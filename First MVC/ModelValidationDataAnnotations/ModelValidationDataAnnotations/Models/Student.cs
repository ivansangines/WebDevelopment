using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelValidationDataAnnotations.Models
{
    public class Student
    {
        [ScaffoldColumn(false)] // will not generate UI element
        public int StudentID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "first name is required"), MaxLength(40)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "last name is required"), MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Range(0, 100, ErrorMessage = "Invalid score..")]
        [Required(ErrorMessage = "test score is required")]
        public int TestScore { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "invalid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "major is required..")]
        [StringLength(10, ErrorMessage = "should be between 2 and 10 characters",MinimumLength =2)]
         public string Major { get; set; }

        [Required(ErrorMessage = "Telephone is required..")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public int Telephone { get; set; }
    }
}