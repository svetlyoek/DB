namespace PetStore.Web.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using PetStore.Services.Contracts;

    public class PetController : Controller
    {
        private readonly IPetService pets;

        public PetController(IPetService pets)
        {
            this.pets = pets;
        }

        public IActionResult All()
        {
            var pets = this.pets.All();

            return this.View(pets);
        }
    }
}