using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public int SelectedNumberOfRows { get; set; } = 10;
        public List<SelectListItem> RowsOptions { get; } = new List<SelectListItem>
        {
        new SelectListItem("10", "10"),
        new SelectListItem("50", "50"),
        new SelectListItem("All", "-1")
        };

        public List<AccountModel> Accounts { get; set; }

        public void OnGet(int accountId, int numberOfRows = 10)
        {
            AccountId = accountId;
            SelectedNumberOfRows = numberOfRows;

            Accounts = _accountService.GetAccountsTransactions(accountId, numberOfRows);
        }
    }
}