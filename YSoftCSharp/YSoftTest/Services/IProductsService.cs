using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YSoftTest.Models;

namespace YSoftTest.Services
{
    public interface IProductsService
    {
        Task<List<Product>> GetProductsPage(int index, int count);
        Task<int> GetProductsTotalCount();
        Task GenerateProductsForDb(int count);
    }
}
