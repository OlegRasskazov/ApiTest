using Infrastructure.Db;
using Infrastructure.Dto.Filters;
using Infrastructure.Extensions;
using Infrastructure.Models;
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

        public void Add(Product[] products)
        {
            _context.Products.AddRange(products);
            _context.SaveChanges();
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Update(Product[] products)
        {
            _context.Products.UpdateRange(products);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }
    }
}
