using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Models.Catalog
{
    public class ProductListModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int StockQuantit { get; set; }

        public CategoryModel CategoryModel { get; set; } = new CategoryModel();
    }
}
