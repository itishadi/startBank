namespace startBank.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string NationalID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public decimal Balance { get; set; }
    }
}
