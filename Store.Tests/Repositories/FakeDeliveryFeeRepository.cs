using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    public class FakeDeliveryFeeRepository : IDeliveryFeeRepository
    {
        public decimal GetDeliveryFee(string zipCode)
        {
            if (zipCode.Equals("59338000"))
            {
                return 29;
            }

            return 10;
        }
    }
}