using Newtonsoft.Json;
using System;

namespace RefactorMe.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal DeliveryPrice { get; private set; }
        [JsonIgnore]
        public bool IsNew { get; private set; }
    }
}
