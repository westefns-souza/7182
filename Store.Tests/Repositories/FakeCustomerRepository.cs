using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer GetCustomer(string document)
        {
            if (document.Equals("12345678911"))
            {
                return new Customer("Westefns", "westefns@outlook.com.br");
            }

            return null;
        }
    }
}