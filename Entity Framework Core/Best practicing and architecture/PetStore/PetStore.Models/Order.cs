namespace PetStore.Models
{
    using PetStore.Models.Enums;
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public Order()
        {
            this.Foods = new HashSet<FoodOrder>();
            this.Pets = new HashSet<Pet>();
            this.Toys = new HashSet<ToyOrder>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public OrderType OrderType { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public ICollection<FoodOrder> Foods { get; set; }

        public ICollection<ToyOrder> Toys { get; set; }
    }
}
