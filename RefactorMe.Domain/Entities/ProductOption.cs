using Newtonsoft.Json;
using System;

namespace RefactorMe.Domain.Entities
{
    public class ProductOption
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; } // TODO: does a ProductOption need to know about the Product?
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public bool IsNew { get; }
    }
}
