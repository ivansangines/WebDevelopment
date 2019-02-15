using MorningBank.DataLayer;
using MorningBank.Models.ViewsModel;
using MorningBank.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MorningBank.BusinessLayer
{
    public class Business : IBusinessAuthentication, IBusinessBanking
    {
        IRepositoryAuthentication _iauth = null;
        IRepositoryBanking _ibank = null;
        public Business(IRepositoryAuthentication iauth, IRepositoryBanking ibank)
        {
            _iauth = iauth;
            _ibank = ibank;
        }
        public Business() : this(GenericFactory<Repository, IRepositoryAuthentication>.GetInstance(), GenericFactory<Repository, IRepositoryBanking>.GetInstance())
        { }

        public bool CheckIfValidUser(string username, string password)
        {
            return _iauth.CheckIfValidUser(username, password);
        }
        public string GetRolesForUser(string username)
        {
            return _iauth.GetRolesForUser(username);
        }
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
        public decimal GetCheckingBalance(long checkingAccountNum)
        {
            return _ibank.GetCheckingBalance(checkingAccountNum);
        }
        public decimal GetSavingBalance(long savingAccountNum)
        {
            return _ibank.GetSavingBalance(savingAccountNum);
        }
        public long GetCheckingAccountNumForUser(string username)
        {
            return _ibank.GetCheckingAccountNumForUser(username);
        }
        public long GetSavingAccountNumForUser(string username)
        {
            return _ibank.GetSavingAccountNumForUser(username);
        }
        public bool TransferCheckingToSaving(long checkingAccountNum, long savingAccountNum, decimal amount)
        {
            return _ibank.TransferCheckingToSaving(checkingAccountNum, savingAccountNum, amount, 0);
        }
        public bool TransferSavingToChecking(long checkingAccountNum, long savingAccountNum, decimal amount)
        {
            return _ibank.TransferSavingToChecking(checkingAccountNum, savingAccountNum, amount, 0);
        }
        List<TransactionHistoryModel> IBusinessBanking.GetTransactionHistory( long checkingAccountNum)
        {
            return _ibank.GetTransactionHistory(checkingAccountNum);
        }


        List<LoanStatus> IBusinessBanking.GetLoanStatus(string role, long checkingAccountNum)
        {
            return _ibank.GetLoanStatus(role, checkingAccountNum);
        }

        bool IBusinessBanking.AcceptLoan(long id, string status, decimal amount, long checkingAccountNum, long savingAccountNum)
        {
            return _ibank.AcceptLoan(id, status, amount, checkingAccountNum, savingAccountNum);
        }

        bool IBusinessBanking.DenyLoan(long id, string status, long checkingAccountNum)
        {
            return _ibank.DenyLoan(id, status, checkingAccountNum);
        }

        public decimal GetBillAmount(long checkingAccountNum)
        {
            return _ibank.GetBillAmount(checkingAccountNum);
        }

        public bool PayBillAmount(long checkingAccountNum,long savingAccountNum, decimal billAmount, decimal amount)
        {
            return _ibank.PayBillAmount(checkingAccountNum,savingAccountNum, billAmount, amount, 0);
        }

        public bool ApplyForLoan(long checkingAccountNum, long savingAccountNum, string userName, decimal amount)
        {
            return _ibank.ApplyForLoan(checkingAccountNum, savingAccountNum, userName, amount, "Pending", -1);
        }
    }
}