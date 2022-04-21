using RefactorMe.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RefactorMe.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        // NB. a different approach might be splitting this into two repositories,
        // IProductRepository and IProductOptionRepository. Given the size of this
        // project and related nature, I've decided to include them in the same file.
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(string name);
        Product GetProduct(Guid id);
        void InsertProduct(Product product);
        void UpdateProduct(Guid id, Product product);
        void DeleteProduct(Guid id);
        IEnumerable<ProductOption> GetOptions(Guid productId);
        ProductOption GetOption(Guid id);
        void InsertOption(Guid productId, ProductOption option);
        void UpdateOption(Guid id, ProductOption option);
        void DeleteOption(Guid id);
    }
}
