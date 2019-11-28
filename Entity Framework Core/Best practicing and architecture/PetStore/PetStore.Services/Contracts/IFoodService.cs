namespace PetStore.Services.Contracts
{
    using System;

    public interface IFoodService
    {
        void Add(string brandName, string foodName, DateTime expdate, decimal price, double weight, int categoryId,int orderId);

        void Remove(string brandName, string foodName,int orderId);

        void GetObject(string name);

        void GetObjectWithCollections(string name);
    }
}
