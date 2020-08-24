using Infrastructure.Dto;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Product GetProduct(int id);

        Product[] GetProducts(Filter filter);

        void SaveProducts(IList<Product> products);
    }
}
