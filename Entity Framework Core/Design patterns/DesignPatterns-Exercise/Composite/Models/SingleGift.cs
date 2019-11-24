using System;

namespace Composite.Models
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, decimal price)
            : base(name, price)
        {
        }

        public override decimal CalculateTotalPrice()
        {
            Console.WriteLine($"{this.name} with price {this.price}");

            return this.price;
        }
    }
}
