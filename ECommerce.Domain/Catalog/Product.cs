using ECommerce.Core;
using System;

namespace ECommerce.Domain
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public int CategoryId { get; set; }

        public int StockQuantity { get; set; }

        public virtual Category Category { get; set; }
    }
}
