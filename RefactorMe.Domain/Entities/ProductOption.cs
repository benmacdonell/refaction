using Newtonsoft.Json;
using System;

namespace RefactorMe.Domain.Entities
{
    public class ProductOption
    {

        public Guid Id { get; set; }
        // TODO: clarify relationship between Product & option --
        // it might not be necessary for a ProductOption to know about
        // a Product, unless there's some other reason for storing this
        // info on the ProductOption.
        public Guid ProductId { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public bool IsNew { get; }
    }
}
