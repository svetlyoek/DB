namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.Food;
    using PetStore.Services.Models.FoodOrder;
    using System;
    using System.Linq;

    public class FoodService : IFoodService
    {

        private readonly PetStoreDbContext data;

        public FoodService(PetStoreDbContext data)
        {
            this.data = data;
        }

      
    }
}

