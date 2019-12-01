namespace PetStore.Web.ViewModels.Pet
{
    using PetStore.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreatePetInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date is required!")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Gender is required!")]
        public AnimalGender Gender { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be positive number!")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be more or at least 1!")]
        public int BreedId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be more or at least 1!")]
        public int CategoryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Id must be more or at least 1!")]
        public int? OrderId { get; set; }


    }
}
