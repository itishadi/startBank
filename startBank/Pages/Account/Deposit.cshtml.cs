using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.BankAppDatas;
using startBank.Models;
using startBank.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
namespace startBank.Pages.Account
{
    [BindProperties]
    public class DepositModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DepositModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Range(100, 10000)]
        public decimal Amount { get; set; }

        public string Comment { get; set; }

        public decimal Balance { get; set; }
        public List<AccountModel> AccountTransaction { get; set; }
        public string SuccessMessage { get; set; }
        public bool ShowSuccessMessage { get; set; }
        public DateTime DepositDate { get; set; }

        public void OnGet(int accountId, int transactionCount)
        {
            AccountTransaction = _accountService.GetAccountsTransactions(accountId, transactionCount);
            DepositDate = DateTime.Now;
            var accountDb = _accountService.GetAccount(accountId);
            Balance = accountDb.Balance;
        }

        public IActionResult OnPost(int accountId)
        {
            var status = _accountService.Deposit(accountId, Amount);


            if(ModelState.IsValid)
            {
                if (status == IAccountService.ErrorMessage.OK)
                {
                    SuccessMessage = "Deposit successful! Your money has been deposited to your account.";
                    ShowSuccessMessage = true;
                }

                if (status == IAccountService.ErrorMessage.IncorrectAmount)
                { ModelState.AddModelError("Amount", "Please enter a correct amount (100-10000)!"); }

                if (DepositDate.AddHours(1) < DateTime.Now)
                { ModelState.AddModelError("WithdrawDate", "Cannot withdraw money in the past!"); }
            }
                if (status == IAccountService.ErrorMessage.OK)
                {
                    TempData["SuccessMessage"] = "Deposit successful!";
                }

                var accountDb = _accountService.GetAccount(accountId);
                Balance = accountDb.Balance;


            return Page();
        }
    }
}

