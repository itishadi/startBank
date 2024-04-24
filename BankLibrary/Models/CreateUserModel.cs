namespace startBank.Models
{
    public class CreateUserModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Department { get; set; }

    }
}
