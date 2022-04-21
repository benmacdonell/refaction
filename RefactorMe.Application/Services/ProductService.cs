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

        public IEnumerable<Guid> GetProducts() {
            return _repository.GetProducts();
        }

        public IEnumerable<Guid> GetProducts(string name)
        {
            return _repository.GetProducts(name);
        }

        public Product GetProduct(Guid id)
        {
            return _repository.GetProduct(id);
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

        public IEnumerable<ProductOption> GetOptions(Guid productId)
        {
            return _repository.GetOptions(productId);
        }

        public ProductOption GetOption(Guid id)
        {
            return _repository.GetOption(id);
        }

        public void CreateOption(Guid productId, ProductOption option)
        {
            _repository.InsertOption(productId, option);
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
