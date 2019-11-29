using System;

namespace PetStore.Services.Models.Food
{
    public class FoodListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ExpirationDate { get; set; }

        public decimal Price { get; set; }

        public double Weight { get; set; }

        public string BrandName { get; set; }

        public string CategoryName { get; set; }
    }
}
