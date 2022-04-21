using RefactorMe.Domain.Entities;
using RefactorMe.Infrastructure.Repositories;
using System;
using System.Collections.Generic;

namespace RefactorMe.Application.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Product> GetProducts() {
            return _repository.GetProducts();
        }

        public IEnumerable<Product> GetProducts(string name)
        {
            return _repository.GetProducts(name);
        }

        public void CreateProduct(Product product)
        {
            _repository.InsertProduct(product);
        }

        public void UpdateProduct(Guid id, Product product)
        {
            _repository.UpdateProduct(id, product);
        }

        public void DeleteProduct(Guid id)
        {
            _repository.DeleteProduct(id);
        }

        public IEnumerable<ProductOption> GetOptions()
        {
            return _repository.GetOptions();
        }

        public ProductOption GetOptions(Guid productId, Guid id)
        {
            return _repository.GetOptions(productId, id);
        }

        public void CreateOption(ProductOption option)
        {
            _repository.InsertOption(option);
        }

        public void UpdateOption(Guid id, ProductOption option)
        {
            _repository.UpdateOption(id, option);
        }

        public void DeleteOption(Guid id)
        {
            _repository.DeleteOption(id);
        }
    }
}
