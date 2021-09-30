using ECommerce.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new Collection<Product>();
        }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
