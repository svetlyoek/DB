namespace PetStore.Services.Contracts
{
    public interface IUserService
    {
        void Add(string name, string email);

        void Remove(string name);

        void GetObject(string name);

        void GetObjectWithCollections(string name);
    }
}
