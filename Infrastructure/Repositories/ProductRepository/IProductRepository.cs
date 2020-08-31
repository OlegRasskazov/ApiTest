using Infrastructure.Dto.Filters;
using Infrastructure.Models;

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

        void Delete(Product product);
    }
}
