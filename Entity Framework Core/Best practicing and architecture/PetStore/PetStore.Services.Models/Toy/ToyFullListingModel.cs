using PetStore.Services.Models.ToyOrder;
using System.Collections.Generic;

namespace PetStore.Services.Models.Toy
{
    public class ToyFullListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string BrandName { get; set; }

        public string CategoryName { get; set; }

        public ICollection<ToyOrderListingModel> Orders { get; set; }
    }
}
