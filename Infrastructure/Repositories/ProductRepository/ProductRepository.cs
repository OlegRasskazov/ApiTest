using Infrastructure.Db;
using Infrastructure.Dto;
using Infrastructure.Extensions;
using Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DataContext _context;

        public ProductRepository(DataContext ctx)
        {
            _context = ctx;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        public Product[] GetProducts(Filter filter)
        {
            var query = _context.Products.ApplyFilter(filter);

            return query.ToArray();
        }

        public void SaveProducts(IList<Product> products)
        {
            _context.Products.AddRange(products);
            _context.SaveChanges();
        }
    }
}
