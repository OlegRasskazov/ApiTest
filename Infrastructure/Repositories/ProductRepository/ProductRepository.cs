using Infrastructure.Models;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Infrastructure.Extensions;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DataContext.DataContext _context;
        public ProductRepository(DataContext.DataContext ctx)
        {
            _context = ctx;
        }
        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        public Product[] GetProducts(Filter filter)
        {
            var x  = _context.Products.Include(p => p.Company).Where(p => p.LoadTime > filter.From && p.LoadTime < filter.To).In  ToSql();
            throw new Exception(x);
            return new Product[1];
        }

        public void SaveProducts(IList<Product> products)
        {

            _context.SaveChanges();
        }
    }
}
