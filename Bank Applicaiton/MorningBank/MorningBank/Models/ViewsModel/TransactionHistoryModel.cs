using MorningBank.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MorningBank.Models.ViewsModel
{
    [Serializable]
    public class TransactionHistoryModel : TransactionHistory
    {
        public string TransactionTypeName { get; set; } // added field

       
    }
}