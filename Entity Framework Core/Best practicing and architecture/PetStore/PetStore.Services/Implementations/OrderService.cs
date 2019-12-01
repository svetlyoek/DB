namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Models.Enums;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.FoodOrder;
    using PetStore.Services.Models.Order;
    using PetStore.Services.Models.Pet;
    using PetStore.Services.Models.ToyOrder;
    using System;
    using System.Linq;

    public class OrderService : IOrderService
    {
        private readonly PetStoreDbContext data;

        public OrderService(PetStoreDbContext data)
        {
            this.data = data;
        }

       
    }
}
