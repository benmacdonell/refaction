using Newtonsoft.Json;
using System;

namespace RefactorMe.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
        [JsonIgnore]
        public bool IsNew { get; set; } // TODO: remove?
    }
}
