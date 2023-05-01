using startBank.BankAppDatas;
using startBank.Models;
using startBank.Pages.Account;

namespace startBank.Services
{
    public interface IAccountService
    {
        public enum ErrorMessage
        {
            OK,
            BalanceTooLow,
            IncorrectAmount,
            AccountNotFound,
            SameAccountTransfer,
            ExceedTransferLimit
        }

        List<AccountModel> GetAccountsTransactions(int acountId, int transactionCount);

        Account GetAccount(int accountId);
        ErrorMessage Withdraw(int accountId, decimal amount);

        ErrorMessage Deposit(int accountId, decimal amount);
        public ErrorMessage Transaction(int fromAccountId, int toAccountId, decimal amount);
       

        }


}
