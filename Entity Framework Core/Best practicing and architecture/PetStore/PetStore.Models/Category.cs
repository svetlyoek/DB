using System.Collections.Generic;

namespace PetStore.Models
{
    public class Category
    {
        public Category()
        {
            this.Foods = new HashSet<Food>();
            this.Pets = new HashSet<Pet>();
            this.Toys = new HashSet<Toy>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Food> Foods { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public ICollection<Toy> Toys { get; set; }

    }
}
