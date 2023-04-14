using Microsoft.CodeAnalysis.Options;

namespace startBank.Models
{
    public class AccountModel
    {
        public int AccountId { get; set; }
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Operation{ get; set; }
        public decimal Balance { get; set; }
    }
}
