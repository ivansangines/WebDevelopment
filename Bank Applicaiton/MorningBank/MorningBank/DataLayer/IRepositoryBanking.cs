using MorningBank.Models.DomainModels;
using MorningBank.Models.ViewsModel;
//using MorningBank.Models.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorningBank.DataLayer
{
    public interface IRepositoryBanking
    {
        decimal GetCheckingBalance(long checkingAccountNum);
        decimal GetSavingBalance(long savingAccountNum);
        decimal GetBillAmount(long checkingAccountNum);
        long GetCheckingAccountNumForUser(string username);
        long GetSavingAccountNumForUser(string username);
        bool TransferCheckingToSaving(long checkingAccountNum, long savingAccountNum, decimal amount, decimal transactionFee);
        bool TransferSavingToChecking(long checkingAccountNum, long savingAccountNum, decimal amount, decimal transactionFee);
        bool PayBillAmount(long checkingAccountNum, long savingAccountNum, decimal billAmount, decimal amount, decimal transactionFee);

        bool ApplyForLoan(long checkingAccountNum, long savingAccountNum, string username, decimal amount, string status, int validation);
        List<TransactionHistoryModel> GetTransactionHistory(long checkingAccountNum);
        List<LoanStatus> GetLoanStatus(string role, long checkingAccountNUm);
        bool AcceptLoan(long id, string status, decimal amount, long checkingAccountNum, long savingAccountNum);
        bool DenyLoan(long id, string status, long checkingAccountNum);
    }
}
