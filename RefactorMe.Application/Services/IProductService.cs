using RefactorMe.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RefactorMe.Application.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        List<Product> GetProducts(string name);
        void CreateProduct(Product product);
        void UpdateProduct(Guid id, Product product);
        void DeleteProduct(Guid id);

        List<ProductOption> GetOptions();
        ProductOption GetOptions(Guid productId, Guid id);
        void CreateOption(ProductOption option);
        void UpdateOption(Guid id, ProductOption option);
        void DeleteOption(Guid id);
    }
}
