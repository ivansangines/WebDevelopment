using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MorningBank.Models.ViewsModel
{
    public class TransferSToCModel
    {
        public decimal SavingBalance { get; set; }
        public decimal CheckingBalance { get; set; }
        [Range(0, 100000, ErrorMessage = "invalid amount specified")]
        public decimal Amount { get; set; }
    }
}