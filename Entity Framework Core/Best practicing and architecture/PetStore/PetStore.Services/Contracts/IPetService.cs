namespace PetStore.Services.Contracts
{
    using PetStore.Services.Models.Pet;
    using System;
    using System.Collections.Generic;

    public interface IPetService
    {
        void Add(string name, DateTime birthdate, string gender, decimal price, int breedId, int categoryId, int orderId);

        void Remove(string name);

        void GetObject(string name);

        IEnumerable<PetListingModel> All();

    }
}
