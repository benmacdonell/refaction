using RefactorMe.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RefactorMe.Application.Services
{
    public interface IProductService
    {
        IEnumerable<Guid> GetProducts();
        IEnumerable<Guid> GetProducts(string name);
        Product GetProduct(Guid id);
        void CreateProduct(Product product);
        void UpdateProduct(Guid id, Product product);
        void DeleteProduct(Guid id);
        IEnumerable<ProductOption> GetOptions(Guid productId);
        ProductOption GetOption(Guid id);
        void CreateOption(Guid productId, ProductOption option);
        void UpdateOption(Guid id, ProductOption option);
        void DeleteOption(Guid id);
    }
}
