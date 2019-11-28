namespace PetStore.Services.Contracts
{
    public interface IBrandService
    {
        void Add(string name);

        void Remove(string name);

        void GetObject(string name);

        void GetObjectWithCollections(string name);

    }
}
