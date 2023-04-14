using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.Models;
using startBank.Pages.ViewModel;
using startBank.Services;

namespace startBank.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
    
        public int AccountId { get; set; }
        public List<AccountModel> Accounts { get; set; }
        public void OnGet(int accountId)
        {
            Accounts = _accountService.GetAccountsTransactions(accountId);
        }

    }
}