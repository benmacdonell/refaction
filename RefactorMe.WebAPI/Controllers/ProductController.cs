using RefactorMe.Application.Services;
using RefactorMe.Domain.Entities;
using RefactorMe.Infrastructure.Repositories;
using RefactorMe.WebAPI.Mappers;
using RefactorMe.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace RefactorMe.WebAPI.Controllers
{
    public class ProductController
    {
       
        [RoutePrefix("products")]
        public class ProductsController : ApiController
        {
            IProductService _productService;
            IProductMapper _productMapper;

            public ProductsController()
            {
                // TODO: connection string should be stored in config
                string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ={ DataDirectory}\Database.mdf; Integrated Security = True";
                IProductRepository repository = new DBProductRepository(connString);
                _productService = new ProductService(repository);
                _productMapper = new ProductMapper();
            }

            /// <summary>
            /// Get all products.
            /// </summary>
            /// <returns>List of all products.</returns>
            [Route]
            [HttpGet]
            public List<Guid> GetAll()
            {
                return _productService.GetProducts().ToList();
            }

            /// <summary>
            /// Get products matching the specified name.
            /// </summary>
            /// <param name="name"></param>
            /// <returns>List of matching products, or not found.</returns>
            [Route]
            [HttpGet]
            public List<Product> SearchByName(string name)
            {
                // NB. an alternative would be to return a 404 here, depending on
                // what the consumer of this API is expecting. I chose an empty list
                // here instead because it can be parsed with the same logic that
                // would handle a populated list, ie. doesn't require an exceptional
                // case to be added on the client side.
                return _productService.GetProducts(name).ToList();
            }

            /// <summary>
            /// Get a product with the specified ID.
            /// </summary>
            /// <param name="id">ID of the product to return.</param>
            /// <returns>Product with matching ID, or not found.</returns>
            [Route("{id}")]
            [HttpGet]
            public Product GetProduct(Guid id)
            {
                var product = _productService.GetProduct(id);
                if (product == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return product;
            }

            /// <summary>
            /// Create a new product.
            /// </summary>
            /// <param name="request">Details of the product to create.</param>
            [Route]
            [HttpPost]
            public void Create(ProductRequest request)
            {
                var product = _productMapper.Map(request);
                if (product == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                _productService.CreateProduct(product);
            }

            /// <summary>
            /// Update a product with the specified ID.
            /// </summary>
            /// <param name="id">ID of the product to update.</param>
            /// <param name="request">The updated product data.</param>
            [Route("{id}")]
            [HttpPut]
            public void Update(Guid id, ProductRequest request)
            {
                // NB. the behaviour of this endpoint has changed - it now 
                // returns a 404 if the Product we're trying to update doesn't
                // exist, rather than creating it anyway, which could lead
                // to unexpected behaviour.
                var existingProduct = _productService.GetProduct(id);
                if (existingProduct == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                // NB2. this could be optimised if performance was an issue -
                // we're doing two lookups: one to verify the product exists
                // (above), and then again internally in the repository to
                // perform the update. We could instead look it up once inside
                // the repository and return a status indicating it wasn't
                // found, but that obscures this process a little so I went
                // with the more explicit approach.
                var updatedProduct = _productMapper.Map(request);
                if (updatedProduct == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                _productService.UpdateProduct(id, updatedProduct);
            }

            /// <summary>
            /// Delete a product with the speicified ID.
            /// </summary>
            /// <param name="id">ID of the product to delete.</param>
            [Route("{id}")]
            [HttpDelete]
            public void Delete(Guid id)
            {
                // NB. again, depending on the client use case we might just
                // want to swallow the error and return OK if the product to delete
                // isn't found.
                var product = _productService.GetProduct(id);
                if (product == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                _productService.DeleteProduct(id);
            }

            /// <summary>
            /// Get all options for this product.
            /// </summary>
            /// <param name="id">ID of the product to get options for.</param>
            /// <returns>List of all options for the specified product, or not found.</returns>
            [Route("{productId}/options")]
            [HttpGet]
            public List<ProductOption> GetOptions(Guid productId)
            {
                var product = _productService.GetProduct(productId);
                if (product == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return _productService.GetOptions(productId).ToList();
            }

            /// <summary>
            /// Get a product option with the specified ID.
            /// </summary>
            /// <param name="id">ID of the product option to return.</param>
            /// <returns>Product option with matching ID, or not found.</returns>
            [Route("{productId}/options/{id}")]
            [HttpGet]
            public ProductOption GetOption(Guid productId, Guid id)
            {
                var option = _productService.GetOption(id);
                if (option == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return option;
            }

            /// <summary>
            /// Create a new option for the specified product.
            /// </summary>
            /// <param name="productId">Product to create the new option for.</param>
            /// <param name="option">The product option to create.</param>
            [Route("{productId}/options")]
            [HttpPost]
            public void CreateOption(Guid productId, ProductOptionRequest request)
            {
                var product = _productService.GetProduct(productId);
                if (product == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                var option = _productMapper.Map(request);
                if (option == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                _productService.CreateOption(productId, option);
            }

            /// <summary>
            /// Update a product option with the specified ID.
            /// </summary>
            /// <param name="id">The ID of the product option to update.</param>
            /// <param name="option">The updated product option data.</param>
            [Route("{productId}/options/{id}")]
            [HttpPut]
            public void UpdateOption(Guid id, ProductOptionRequest request)
            {
                var existingOption = _productService.GetOption(id);
                if (existingOption == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                var updatedOption = _productMapper.Map(request);
                if (updatedOption == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                _productService.UpdateOption(id, updatedOption);
            }

            /// <summary>
            /// Delete a product option with the speicified ID.
            /// </summary>
            /// <param name="id">ID of the product option to delete.</param>
            [Route("{productId}/options/{id}")]
            [HttpDelete]
            public void DeleteOption(Guid id)
            {
                var option = _productService.GetOption(id);
                if (option == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                _productService.DeleteOption(id);
            }
        }
    }
}
