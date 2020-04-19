using System;

namespace Store.Domain.Entities
{
    public class Discount : Entity
    {
        public Discount(decimal amount, DateTime expiresDate)
        {
            Amount = amount;
            ExpiresDate = expiresDate;
        }

        public decimal Amount { get; private set; }
        public DateTime ExpiresDate { get; private set; }

        public bool IsValid()
        {
            return DateTime.Compare(DateTime.Now, ExpiresDate) < 0;
        }

        public decimal Value()
        {
            return IsValid() ? Amount : 0;
        }
    }
}