using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MorningBank.Models.ViewsModel
{
    public class LoanStatus : EntityBase
    {
        public long Loanid { get; set; }
        public string UserName { get; set; }
        public long CheckingAccountNumber { get; set; }
        public long SavingAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public int Validation { get; set; }
    }
}