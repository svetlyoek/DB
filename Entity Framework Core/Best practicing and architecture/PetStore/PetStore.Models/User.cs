namespace PetStore.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
