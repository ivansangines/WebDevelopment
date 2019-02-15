using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MorningBank.Models.ViewsModel
{
    public class PhoneBill
    {
        public decimal CheckingBalance { get; set; }
        public decimal BillAmount { get; set; }
        [Range(0, 100000, ErrorMessage = "invalid amount specified")]
        public decimal Amount { get; set; }
    }
}