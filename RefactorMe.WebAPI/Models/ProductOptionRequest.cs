using System;

namespace RefactorMe.WebAPI.Models
{
    public class ProductOptionRequest
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
