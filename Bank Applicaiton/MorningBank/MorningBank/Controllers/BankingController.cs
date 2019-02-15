using MorningBank.BusinessLayer;
using MorningBank.Models.DomainModels;
using MorningBank.Models.ViewsModel;
using MorningBank.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MorningBank.Controllers
{
    [Authorize]
    public class BankingController : Controller
    {
        // GET: Banking
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PayBill()
        {
            PhoneBill pb = new PhoneBill();
            UserInfo ui = CookieFacade.USERINFO;
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            pb.CheckingBalance = ibank.GetCheckingBalance(ui.CheckingAcccountNumber);
            pb.BillAmount = ibank.GetBillAmount(ui.CheckingAcccountNumber);
            pb.Amount = 0;
            ViewBag.Message = "";
            return View(pb);
        }

        [HttpPost]
        public ActionResult PayBill(PhoneBill pb)
        {
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo uinfo = CookieFacade.USERINFO;

            try
            {
                bool valid = ibank.PayBillAmount(uinfo.CheckingAcccountNumber,uinfo.SavingAccountNumber, pb.BillAmount, pb.Amount);
                if (valid == true)
                {
                    ViewBag.Message = "Payment successful!";
                    ModelState.Clear();
                    pb.Amount = 0;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            pb.CheckingBalance = ibank.GetCheckingBalance(uinfo.CheckingAcccountNumber);
            pb.BillAmount = ibank.GetBillAmount(uinfo.CheckingAcccountNumber);

            return View(pb);

        }

        public ActionResult TransferSavingToChecking()
        {
            TransferSToCModel tsc = new TransferSToCModel();
            UserInfo uinfo = CookieFacade.USERINFO;
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            tsc.SavingBalance = ibank.GetSavingBalance(uinfo.SavingAccountNumber);
            tsc.CheckingBalance = ibank.GetCheckingBalance(uinfo.CheckingAcccountNumber);
            tsc.Amount = 5;
            ViewBag.Message = "";
            return View(tsc);
        }

        [HttpPost]
        public ActionResult TransferSavingToChecking(TransferSToCModel tsc)
        {
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo uinfo = CookieFacade.USERINFO;

            try
            {
                bool valid = ibank.TransferSavingToChecking(uinfo.CheckingAcccountNumber, uinfo.SavingAccountNumber, tsc.Amount);
                if (valid == true)
                {
                    ViewBag.Message = "Transfer successful!";
                    ModelState.Clear();
                    tsc.Amount = 0;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            tsc.SavingBalance = ibank.GetSavingBalance(uinfo.SavingAccountNumber);
            tsc.CheckingBalance = ibank.GetCheckingBalance(uinfo.CheckingAcccountNumber);
            
            return View(tsc);

        }

        public ActionResult TransferCheckingToSaving()
        {
            TransferCToSModel tcs = new TransferCToSModel();
            UserInfo ui = CookieFacade.USERINFO;
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            tcs.CheckingBalance = ibank.GetCheckingBalance(ui.CheckingAcccountNumber);
            tcs.SavingBalance = ibank.GetSavingBalance(ui.SavingAccountNumber);
            tcs.Amount = 5;
            ViewBag.Message = "";
            return View(tcs);
        }
        [HttpPost]
        public ActionResult TransferCheckingToSaving(TransferCToSModel tcs)
        {
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo ui = CookieFacade.USERINFO;
            try
            {
                if (ModelState.IsValid)
                {
                    bool ret = ibank.TransferCheckingToSaving(ui.CheckingAcccountNumber, ui.SavingAccountNumber, tcs.Amount);
                    if (ret == true)
                    {
                        ViewBag.Message = "Transfer successful..";
                        ModelState.Clear(); // otherwise, textbox will display the old amount
                        tcs.Amount = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            tcs.CheckingBalance = ibank.GetCheckingBalance(ui.CheckingAcccountNumber);
            tcs.SavingBalance = ibank.GetSavingBalance(ui.SavingAccountNumber);
            return View(tcs);
        }

        public ActionResult TransferHistory()
        {
            IBusinessBanking ibank = GenericFactory<Business,IBusinessBanking>.GetInstance();
            UserInfo ui = CookieFacade.USERINFO;
            List<TransactionHistoryModel> THList = ibank.GetTransactionHistory(ui.CheckingAcccountNumber);
            TransactionHistoryModel thm = new TransactionHistoryModel();
            return View(THList);
        }

        public ActionResult ApplyForLoan()
        {
            LoanApplicationModel loan = new LoanApplicationModel();
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo ui = CookieFacade.USERINFO;
            loan.CheckingBalance = ibank.GetCheckingBalance(ui.CheckingAcccountNumber);
            loan.SavingBalance = ibank.GetSavingBalance(ui.SavingAccountNumber);
            loan.Amount = 500;
            ViewBag.Message = "";
            return View(loan);

        }

        [HttpPost]
        public ActionResult ApplyForLoan(LoanApplicationModel lo)
        {
            
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo ui = CookieFacade.USERINFO;
            decimal amount = lo.Amount;
            string us = ui.Username;
            if ((us.ToUpper()) != ("ADMIN"))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        bool ret = ibank.ApplyForLoan(ui.CheckingAcccountNumber, ui.SavingAccountNumber, ui.Username, amount);
                        if (ret == true)
                        {
                            ViewBag.Message = "Application successful..";
                            ModelState.Clear(); // otherwise, textbox will display the old amount
                            lo.Amount = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }

                lo.CheckingBalance = ibank.GetCheckingBalance(ui.CheckingAcccountNumber);
                lo.SavingBalance = ibank.GetSavingBalance(ui.SavingAccountNumber);
            }
            else
            {
                ViewBag.Message = "Admin not allowed to apply for Loan";
            }
            return View(lo);
        }

        public ActionResult LoanStatus()
        {
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo ui = CookieFacade.USERINFO;
            List<LoanStatus> LSList = ibank.GetLoanStatus(ui.Role, ui.CheckingAcccountNumber);
            LoanStatus ls = new LoanStatus();
            return View(LSList);
        }
        

        public ActionResult AcceptLoan(long id, decimal amount, long checking, long saving)
        {
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo ui = CookieFacade.USERINFO;
            List<LoanStatus> LSList = null;
            bool res= ibank.AcceptLoan(id,"Accepted", amount, checking, saving);
            if (res)
            {
                LSList = ibank.GetLoanStatus(ui.Role, ui.CheckingAcccountNumber);
            }
            return View("LoanStatus",LSList);
        }

        public ActionResult DenyLoan(long id, long checking)
        {
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo ui = CookieFacade.USERINFO;
            List<LoanStatus> LSList = null;
            bool res = ibank.DenyLoan(id, "Denied", checking);
            if (res)
            {
                LSList = ibank.GetLoanStatus(ui.Role, ui.CheckingAcccountNumber);
            }
            return View("LoanStatus", LSList);
        }




    }
}