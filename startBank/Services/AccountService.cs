using Microsoft.Build.Evaluation;
using startBank.BankAppDatas;
using startBank.Data;
using startBank.Models;
using startBank.Services;
using static startBank.Services.IAccountService;

public class AccountService : IAccountService
{
    private readonly BankAppDataContext _dbContext;

    public AccountService(BankAppDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<AccountModel> GetAccountsTransactions(int accountId)
    {
       var transactions = _dbContext.Transactions
            .Where(a => a.AccountId == accountId)
            .OrderByDescending(a => a.Date)
            .OrderByDescending(a => a.TransactionId)
               .Select(a => new AccountModel
               {
                   AccountId = accountId,
                   Balance = a.Balance,
                   Date = a.Date,
                   TransactionId = a.TransactionId,
                   Operation = a.Operation,
                   Amount = a.Balance,

               }).ToList();
            return transactions;
    }

    public Account GetAccount(int accountId)
    {
        return _dbContext.Accounts.First(a => a.AccountId == accountId);
    }

    public ErrorMessage Withdraw(int accountId, decimal amount)
    {
        if (amount < 100 || amount > 10000)
        {
            return ErrorMessage.IncorrectAmount;
        }

        var account = _dbContext.Accounts.First(a => a.AccountId == accountId);
        if (account == null)
        {
            return ErrorMessage.AccountNotFound;
        }

        if (account.Balance < amount)
        {
            return ErrorMessage.BalanceTooLow;
        }

        account.Balance -= amount;
        var transaction = new Transaction
        {
            AccountId = accountId,
            Date = DateTime.Now,
            Operation = "Withdraw",
            Type = "Credit",
            Amount = amount * -1,
            Balance = account.Balance
        };
        _dbContext.Transactions.Add(transaction);
        _dbContext.SaveChanges();

        return ErrorMessage.OK;
    }
    public ErrorMessage Deposit ( int accountId, decimal amount)
    {
        if (amount < 100 || amount > 10000)
        {
            return ErrorMessage.IncorrectAmount;
        }

        var account = _dbContext.Accounts.First(a => a.AccountId == accountId);
        if (account == null)
        {
            return ErrorMessage.AccountNotFound;
        }

        if (account.Balance < amount)
        {
            return ErrorMessage.BalanceTooLow;
        }

        account.Balance += amount;
        var transaction = new Transaction
        {
            AccountId = accountId,
            Date = DateTime.Now,
            Operation = "Deposit",
            Type = "Credit",
            Amount = amount,
            Balance = account.Balance
        };
        _dbContext.Transactions.Add(transaction);
        _dbContext.SaveChanges();

        return ErrorMessage.OK;
    }




}
