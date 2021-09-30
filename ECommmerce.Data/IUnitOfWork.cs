using ECommerce.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        Task<int> CommitAsync();
    }
}
