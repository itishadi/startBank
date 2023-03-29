using startBank.BankAppDatas;
using static startBank.Pages.CustomerModel;

namespace startBank.Services
{
    public interface ICustomerService
    {
      List<CustomerViewModel> GetCustomers(string sortColumn, string sortOrder);

    }
}
