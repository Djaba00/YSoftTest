using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using YSoftTest.DataContext;
using YSoftTest.Models;

namespace YSoftTest.Services
{
    public class ProductsService : IProductsService, IDisposable
    {
        private ApplicationContext db { get; set; }

        public ProductsService(ApplicationContext context)
        {
            db = context;
        }

        public async Task<List<Product>> GetProductsPage(int index, int count)
        {
            IQueryable<Product> productsQuer = db.Products;

            var products = await productsQuer
                .OrderBy(p => p.Id)
                .Skip((index - 1) * count)
                .Take(count)
                .ToListAsync();

            return products;
        }

        public async Task<int> GetProductsTotalCount()
        {
            return await db.Products.CountAsync();
        }

        public async Task GenerateProductsForDb(int count)
        {
            var products = GenerateProducts.Generate(count);

            db.Products.AddRange(products);

            await db.SaveChangesAsync();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}