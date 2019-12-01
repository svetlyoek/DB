namespace PetStore.Services.Models.User
{
    using PetStore.Services.Models.Order;
    using System.Collections.Generic;

    public class UserFullListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<OrderListingModel> Orders { get; set; }
    }
}
