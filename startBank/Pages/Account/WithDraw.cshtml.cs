using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using startBank.Models;
using startBank.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace startBank.Pages.Account
{
    [BindProperties]

    public class WithDrawModel : PageModel
    {
        private readonly IAccountService _accountService;
        public WithDrawModel(IAccountService accountService)
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
        public DateTime WithdrawDate { get; set; }

        public void OnGet(int accountId)
        {
            AccountTransaction = _accountService.GetAccountsTransactions(accountId);
            WithdrawDate = DateTime.Now;
            var accountDb = _accountService.GetAccount(accountId);
            Balance = accountDb.Balance;

        }

        public IActionResult OnPost(int accountId)
        {
           

            var status = _accountService.Withdraw(accountId, Amount);

            if (status == IAccountService.ErrorMessage.OK)
            {
                SuccessMessage = "Withdrawal successful!Your money has been withdrawn from your account.";
                ShowSuccessMessage = true;
            }

            if (status == IAccountService.ErrorMessage.IncorrectAmount)
            { ModelState.AddModelError("Amount", "Please enter a correct amount (100-10000)!"); }

            if (WithdrawDate.AddHours(1) < DateTime.Now)
            { ModelState.AddModelError("WithdrawDate", "Cannot withdraw money in the past!"); }

            var accountDb = _accountService.GetAccount(accountId);
            Balance = accountDb.Balance;
            TempData["SuccessMessage"] = "Withdraw successful!";

            return Page();
        }


    }


}
