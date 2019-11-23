﻿namespace Facade.Models
{
    public class Car
    {
        public string Type { get; set; }

        public string Color { get; set; }

        public int NumberOfDoors { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return $"Car type: {this.Type}, Color: {this.Color}, Number of doors: {this.NumberOfDoors}, Manufactured in: " +
                $"{this.City}, At address: {this.Address}.";
        }
    }
}
