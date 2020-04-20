using System;
using System.Collections.Generic;
using Store.Domain.Commands;

namespace Store.Domain.Utils
{
    public static class ExtractGuids
    {
        public static IEnumerable<Guid> Extract(IList<CreateOrderItemCommand> items)
        {
            var guides = new List<Guid>();

            foreach (var item in items)
            {
                guides.Add(item.Product);
            }

            return guides;
        }
    } 
}