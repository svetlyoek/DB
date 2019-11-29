namespace PetStore.Models
{
    using System.Collections.Generic;

    public class Brand
    {
        public Brand()
        {
            this.Toys = new HashSet<Toy>();
            this.Foods = new HashSet<Food>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Toy> Toys { get; set; }

        public ICollection<Food> Foods { get; set; }

    }
}
