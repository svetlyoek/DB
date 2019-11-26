using System.Collections.Generic;

namespace PetStore.Models
{
    public class Breed
    {
        public Breed()
        {
            this.Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; }
    }
}
