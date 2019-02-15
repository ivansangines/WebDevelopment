using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WizardMVC.Models
{
    public class CustomerInfo
    {
        // fields that we need to collect in different wizard steps
        [Required(ErrorMessage = "{0} is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "invalid email..")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(2, ErrorMessage = "needs to be two chars")]
        [MinLength(2)]
        public string State { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [Range(1000, 10000, ErrorMessage = "needs to be between 1000-10000")]
        public int CustomerPin { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.CreditCard)]
        public int CardNumber { get; set; }


        [DisplayFormat(DataFormatString = "{0:MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }
    }
}