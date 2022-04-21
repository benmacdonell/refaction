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
            _repository = repository;
        }

        public IEnumerable<Guid> GetProducts() {
            return _repository.GetProducts();
        }

        public IEnumerable<Guid> GetProducts(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Product name not specified");
            }

            return _repository.GetProducts(name);
        }

        public Product GetProduct(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentException("Product ID must not be null");
            }

            return _repository.GetProduct(id);
        }

        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentException("Product must not be null");
            }

            _repository.InsertProduct(product);
        }

        public void UpdateProduct(Guid id, Product product)
        {
            if (id == null)
            {
                throw new ArgumentException("Product ID must not be null");
            }
            if (product == null)
            {
                throw new ArgumentException("Product must not be null");
            }

            _repository.UpdateProduct(id, product);
        }

        public void DeleteProduct(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentException("Product ID must not be null");
            }
            _repository.DeleteProduct(id);
        }

        public IEnumerable<ProductOption> GetOptions(Guid productId)
        {
            if (productId == null)
            {
                throw new ArgumentException("Product ID must not be null");
            }

            return _repository.GetOptions(productId);
        }

        public ProductOption GetOption(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentException("Product option ID must not be null");
            }

            return _repository.GetOption(id);
        }

        public void CreateOption(Guid productId, ProductOption option)
        {
            if (productId == null)
            {
                throw new ArgumentException("Product ID must not be null");
            }
            if (option == null)
            {
                throw new ArgumentException("Product option must not be null");
            }
            _repository.InsertOption(productId, option);
        }

        public void UpdateOption(Guid id, ProductOption option)
        {
            if (id == null)
            {
                throw new ArgumentException("Product option ID must not be null");
            }
            if (option == null)
            {
                throw new ArgumentException("Product option must not be null");
            }
            _repository.UpdateOption(id, option);
        }

        public void DeleteOption(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentException("Product option ID must not be null");
            }
            _repository.DeleteOption(id);
        }
    }
}
