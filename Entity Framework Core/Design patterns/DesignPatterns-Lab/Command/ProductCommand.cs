using Command.Contracts;
using Command.Enumerations;
using Command.Models;

namespace Command
{
    public class ProductCommand : ICommand
    {
        private readonly Product product;

        private readonly PriceAction action;

        private readonly int amount;

        public ProductCommand(Product product, PriceAction action, int amount)
        {
            this.product = product;
            this.action = action;
            this.amount = amount;
        }

        public void ExecuteAction()
        {
            if (action == PriceAction.Increase)
            {
                this.product.IncreasePrice(this.amount);
            }
            else
            {
                this.product.DecreasePrice(this.amount);
            }
        }

    }
}
