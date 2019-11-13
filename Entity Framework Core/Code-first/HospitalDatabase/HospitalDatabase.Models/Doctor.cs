namespace HospitalDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Doctor
    {
        public int DoctorId { get; set; }

        public string Name { get; set; }

        public string Specialty { get; set; }

        [MinLength(4)]
        public string Password { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();
    }
}