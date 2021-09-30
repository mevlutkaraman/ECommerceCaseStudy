using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Models.Catalog
{
    public class ProductModel : BaseEntityModel
    {
        public string Title  { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int StockQuantity { get; set; }
    }
}
