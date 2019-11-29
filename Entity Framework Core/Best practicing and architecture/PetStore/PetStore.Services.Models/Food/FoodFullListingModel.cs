namespace PetStore.Services.Models.Food
{
    using PetStore.Services.Models.FoodOrder;
    using System;
    using System.Collections.Generic;

    public class FoodFullListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ExpirationDate { get; set; }

        public decimal Price { get; set; }

        public double Weight { get; set; }

        public string BrandName { get; set; }

        public string CategoryName { get; set; }

        public ICollection<FoodOrderListingModel> Orders { get; set; }
    }
}
