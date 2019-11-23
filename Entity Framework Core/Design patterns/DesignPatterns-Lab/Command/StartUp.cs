namespace Command
{
    using Command.Contracts;
    using Command.Enumerations;
    using Command.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();

            var phone = new Product("Phone", 250.50m);

            var laptop = new Product("Laptop", 780);

            Execute(phone, modifyPrice, new ProductCommand(phone, PriceAction.Increase, 100));

            Execute(laptop, modifyPrice, new ProductCommand(laptop, PriceAction.Decrease, 200));

        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand command)
        {
            modifyPrice.SetCommand(command);

            modifyPrice.Invoke();
        }
    }
}
