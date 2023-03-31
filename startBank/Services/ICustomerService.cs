using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using startBank.BankAppDatas;
using static startBank.Pages.CustomerModel;

namespace startBank.Services
{
    public interface ICustomerService
    {
      List<CustomerViewModel> GetCustomers(int oneCustomerId, string sortColumn, string sortOrder, int p, string q);

    }
}
