using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using startBank.BankAppDatas;
using startBank.Models;
using startBank.Services;
using static startBank.Services.IAccountService;

namespace startBank.Pages.Account
{
    public class TransactionsModel : PageModel
    {

        private readonly IAccountService _accountService;

        public TransactionsModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public List<AccountModel> AccountTransaction { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Balance { get; set; }
        [Required]
        public decimal? Amount { get; set; }
        public int AccountId { get; set; }
        public int ToAccountId { get; set; }
        public string SuccessMessage { get; set; }
        public bool ShowSuccessMessage { get; set; }

        public void OnGet(int accountId, int numberOfRows)
        {
            AccountTransaction = _accountService.GetAccountsTransactions(accountId, numberOfRows);
            TransactionDate = DateTime.Now;
            var accountDb = _accountService.GetAccount(accountId);
            Balance = accountDb.Balance;
        }
        public IActionResult OnPost(int AccountId, int toAccountId, decimal amount)
        {
            var result = _accountService.Transaction(AccountId, toAccountId, amount);

            if(ModelState.IsValid) { 
            if (result == IAccountService.ErrorMessage.OK)
            {
                SuccessMessage = "Deposit successful! Your money has been deposited to your account.";
                ShowSuccessMessage = true;
            }
            else
            {
                switch (result)
                {
                    case IAccountService.ErrorMessage.IncorrectAmount:
                        ModelState.AddModelError("", "The amount must be between 100 and 10,000.");
                        break;
                    case IAccountService.ErrorMessage.AccountNotFound:
                        ModelState.AddModelError("", "One or more of the specified accounts could not be found.");
                        break;
                    case IAccountService.ErrorMessage.BalanceTooLow:
                        ModelState.AddModelError("", "The balance of the source account is too low to make the transfer.");
                        break;
                    case IAccountService.ErrorMessage.SameAccountTransfer:
                        ModelState.AddModelError("", "Cannot transfer to the same account.");
                        break;
                    case IAccountService.ErrorMessage.ExceedTransferLimit:
                        ModelState.AddModelError("", "The transfer limit has been exceeded for this account.");
                        break;
                    default:
                        ModelState.AddModelError("", "An error occurred while transferring funds.");
                        break;
                }

            }
            }
                if (result == IAccountService.ErrorMessage.OK)
                {
                    TempData["SuccessMessage"] = "Deposit successful!";
                }
            var accountDb = _accountService.GetAccount(AccountId);
                Balance = accountDb.Balance;
                //TempData["SuccessMessage"] = "Transfer successful!";
                return Page();
        }

    }
}
