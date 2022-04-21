using RefactorMe.Domain.Entities;
using RefactorMe.WebAPI.Models;

namespace RefactorMe.WebAPI.Mappers
{
    public class ProductMapper: IProductMapper
    {
        public Product Map(ProductRequest request)
        {
            if (request == null)
            {
                return null;
            }

            return new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                DeliveryPrice = request.DeliveryPrice
            };
        }

        public ProductOption Map(ProductOptionRequest request)
        {
            if (request == null)
            {
                return null;
            }

            return new ProductOption
            {
                ProductId = request.ProductId,
                Name = request.Name,
                Description = request.Description
            };
        }
    }
}
