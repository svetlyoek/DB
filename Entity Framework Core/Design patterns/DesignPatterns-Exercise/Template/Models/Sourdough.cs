namespace Template.Models
{
    using System;

    public class Sourdough : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Sourdough bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking Sourdough bread. (20 minutes)");
        }
    }
}
