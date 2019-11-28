namespace PetStore.Services.Contracts
{
    public interface IOrderService
    {
        void Add(string name, int userId);

        void Remove(string name);

        void GetObject(string name);

        void GetObjectWithCollections(string name);
    }
}
