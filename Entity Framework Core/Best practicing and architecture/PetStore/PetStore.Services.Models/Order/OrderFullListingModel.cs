namespace PetStore.Services.Models.Order
{
    using PetStore.Services.Models.FoodOrder;
    using PetStore.Services.Models.Pet;
    using PetStore.Services.Models.ToyOrder;
    using System;
    using System.Collections.Generic;

    public class OrderFullListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string UserName { get; set; }

        public ICollection<PetListingModel> Pets { get; set; }

        public ICollection<FoodOrderListingModel> Foods { get; set; }

        public ICollection<ToyOrderListingModel> Toys { get; set; }

    }
}
