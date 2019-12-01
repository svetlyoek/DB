namespace PetStore.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.Pet;
    using PetStore.Web.ViewModels.Pet;

    public class PetController : Controller
    {
        private readonly IPetService pets;
        private IMapper mapper;

        public PetController(IPetService pets, IMapper mapper)
        {
            this.pets = pets;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreatePetInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var petModel = mapper.Map<PetCreateServiceModel>(model);

            this.pets.Add(petModel);

            return this.RedirectToAction("All", "Pet");
        }

        public IActionResult DeleteDetails(int id)
        {
            var pet = this.pets.Details(id);

            return this.View(pet);

        }

        public IActionResult Delete(int id)
        {
            this.pets.Remove(id);

            return this.View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pet = this.pets.Edit(id);

            var petModel = mapper.Map<CreatePetInputModel>(pet);

            return this.View(petModel);

        }

        [HttpPost]
        public IActionResult Edit(CreatePetInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var petModel = mapper.Map<PetEditListingModel>(model);

            this.pets.Edit(petModel);

            return this.RedirectToAction("All", "Pet");

        }

        public IActionResult All()
        {
            var pets = this.pets.All();

            return this.View(pets);
        }

        public IActionResult Details(int id)
        {
            var pet = this.pets.Details(id);

            var petToProject = new DetailsPetModel
            {
                Id = pet.Id,
                Name = pet.Name,
                Birthdate = pet.Birthdate,
                Gender = pet.Gender,
                Breed = pet.Breed,
                BreedId = pet.BreedId,
                Category = pet.Category,
                CategoryId = pet.CategoryId,
                Order = pet.Order,
                OrderId = pet.OrderId,
                Price = pet.Price,
                Description = pet.Description

            };

            return this.View(petToProject);
        }

    }
}