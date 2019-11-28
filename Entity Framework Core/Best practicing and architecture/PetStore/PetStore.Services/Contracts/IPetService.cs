namespace PetStore.Services.Contracts
{
    using System;

    public interface IPetService
    {
        void Add(string name, DateTime birthdate, string gender, decimal price, int breedId, int categoryId, int orderId);

        void Remove(string name);

        void GetObject(string name);

    }
}
