namespace Template.Models
{
    using System;

    public class WholeWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for WholeWheat bread.");

        }

        public override void Bake()
        {
            Console.WriteLine("Baking WholeWheat bread. (15 minutes)");
        }
    }
}
