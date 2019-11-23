namespace Facade
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                .WithType("BMW")
                .WithColor("blue")
                .WithNumberOfDoors(4)
                .Address
                .WithCity("Sofia")
                .WithAddress("Ivan Vazov 15")
                .Build();

            Console.WriteLine(car);

        }
    }
}
