﻿using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Items
{
    public class CreateItemInputModel
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [Range(typeof(decimal), "0", "1000")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
