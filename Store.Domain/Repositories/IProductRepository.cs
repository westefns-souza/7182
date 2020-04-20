using System;
using System.Collections.Generic;
using Store.Domain.Entities;

namespace Store.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(IEnumerable<Guid> ids);
    }
}