namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.Order;
    using PetStore.Services.Models.User;
    using System;
    using System.Linq;

    public class UserService : IUserService
    {
        public readonly PetStoreDbContext data;

        public UserService(PetStoreDbContext data)
        {
            this.data = data;
        }

        


    }
}
