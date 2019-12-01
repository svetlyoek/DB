namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;

    public class Food
    {
        public Food()
        {
            this.Orders = new HashSet<FoodOrder>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ExpirationDate { get; set; }

        public decimal Price { get; set; }

        public double Weight { get; set; }

        public int? BrandId { get; set; }

        public Brand Brand { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<FoodOrder> Orders { get; set; }
    }
}
