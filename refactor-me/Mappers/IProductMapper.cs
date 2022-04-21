using RefactorMe.Domain.Entities;
using RefactorMe.WebAPI.Models;

namespace RefactorMe.WebAPI.Mappers
{
    public interface IProductMapper
    {
        Product Map(ProductRequest request);
        ProductOption Map(ProductOptionRequest request);
    }
}
