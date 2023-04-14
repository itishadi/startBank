using Microsoft.VisualStudio.Debugger.Contracts.HotReload;

namespace startBank.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string NationalID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public int AccountId { get; set; }
        public string City { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalBalance { get; set; }
    }
}
