namespace PetStore.Services.Models.Order
{
    using System;

    public class OrderListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string UserName { get; set; }
    }
}
