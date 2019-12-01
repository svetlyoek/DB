namespace PetStore.Web.MappingConfiguration
{
    using AutoMapper;
    using PetStore.Services.Models.Pet;
    using PetStore.Web.ViewModels.Pet;

    public class PetStoreProfile : Profile
    {
        public PetStoreProfile()
        {
            this.CreateMap<CreatePetInputModel, PetCreateServiceModel>();
            this.CreateMap<PetCreateServiceModel, CreatePetInputModel>();
            this.CreateMap<CreatePetInputModel, PetEditListingModel>();
        }
    }
}
