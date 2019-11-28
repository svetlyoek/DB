namespace PetStore.Services.Contracts
{
    public interface IToyService
    {
        void Add(string brandName, string toyName, decimal price, int categoryId, int orderId);

        void Remove(string brandName, string toyName, int orderId);

        void GetObject(string name);

        void GetObjectWithCollections(string name);
    }
}
