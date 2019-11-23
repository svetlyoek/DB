namespace Singelton
{
    using Singelton.Models;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var firstDb = SingeltonDataContainer.Instance;

            Console.WriteLine(firstDb.GetPopulation("Tokyo"));

            var secondDb = SingeltonDataContainer.Instance;

            Console.WriteLine(secondDb.GetPopulation("Madrid"));
        }
    }
}
