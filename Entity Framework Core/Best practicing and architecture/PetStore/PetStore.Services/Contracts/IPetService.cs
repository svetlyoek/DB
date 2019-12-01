namespace PetStore.Services.Contracts
{
    using PetStore.Services.Models.Pet;
    using System.Collections.Generic;

    public interface IPetService
    {
        void Add(PetCreateServiceModel model);

        void Remove(int id);

        PetCreateServiceModel Edit(int id);

        void Edit(PetEditListingModel model);

        PetFullListingModel Details(int id);

        IEnumerable<PetListingModel> All();

    }
}
