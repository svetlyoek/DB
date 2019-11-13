﻿namespace HospitalDatabase.Models
{
    using System.Collections.Generic;

    public class Medicament
    {
        public int MedicamentId { get; set; }

        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}
