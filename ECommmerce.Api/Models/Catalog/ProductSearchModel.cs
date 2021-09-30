using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Models.Catalog
{
    public class ProductSearchModel
    {
        public string Keywords { get; set; }

        public int MinimumStockQuantity { get; set; }

        public int MaximumStockQuantity { get; set; }
    }
}
