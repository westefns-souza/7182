namespace Store.Domain.Repositories.Interfaces
{
    public interface IDeliveryFeeRepository
    {
        decimal GetDeliveryFee(string zipCode);
    }
}