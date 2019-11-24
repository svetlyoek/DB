namespace Prototype
{
    using Prototype.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SandwichMenu menu = new SandwichMenu();

            menu["BLT"] = new Sandwich("Wheat", "Bacon", "Emental", "Lettuce, Tomatoes");

            menu["Vegetarian"] = new Sandwich("Wheat", "", "", "Cucumber");

            Sandwich firstSandwich = menu["BLT"].Clone() as Sandwich;

            Sandwich secondSandwich = menu["Vegetarian"].Clone() as Sandwich;
        }
    }
}
