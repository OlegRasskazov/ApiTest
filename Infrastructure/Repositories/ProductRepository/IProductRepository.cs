using Infrastructure.Dto;
using Infrastructure.Dto.Filters;
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

        void Add(Product[] products);

        void Add(Product product);

        void Update(Product product);

        void Update(Product[] products);
    }
}
