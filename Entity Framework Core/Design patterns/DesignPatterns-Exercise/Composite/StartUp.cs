namespace Composite
{
    using Composite.Models;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            var phone = new SingleGift("Samsung", 450.50m);
            phone.CalculateTotalPrice();
            Console.WriteLine("----------------------------------------------------");

            var rootBox = new CompositeGift("RootBox", 0m);
            var truckToy = new SingleGift("Truck Toy", 65.60m);
            var soldierToy = new SingleGift("Soldier Toy", 120m);

            rootBox.Add(truckToy);
            rootBox.Add(soldierToy);

            Console.WriteLine($"Total price of the compsoite present is: {rootBox.CalculateTotalPrice()}");
        }
    }
}
