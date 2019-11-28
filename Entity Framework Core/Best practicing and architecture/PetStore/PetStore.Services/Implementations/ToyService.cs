namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.Toy;
    using PetStore.Services.Models.ToyOrder;
    using System;
    using System.Linq;

    public class ToyService : IToyService
    {
        private readonly PetStoreDbContext data;

        public ToyService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Add(string brandName, string toyName, decimal price, int categoryId, int orderId)
        {
            if (brandName.Length > DataValidation.BrandNameLength)
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(brandName))
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Brands.Any(b => b.Name == brandName))
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NotExistingBrand);
            }

            else if (toyName.Length > DataValidation.ToyNameLength)
            {
                throw new ArgumentException(ExceptionMessages.ToyExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(toyName))
            {
                throw new ArgumentException(ExceptionMessages.ToyExceptions.NameNullOrEmptyException);
            }

            else if (price <= 0)
            {
                throw new ArgumentException(ExceptionMessages.ToyExceptions.PriceException);
            }

            var brand = this.data
                .Brands
                .FirstOrDefault(b => b.Name == brandName);

            if (!this.data.Toys.Any(t => t.Name == toyName))
            {
                var toy = new Toy
                {
                    Name = toyName,
                    Price = price,
                    CategoryId = categoryId,
                    BrandId = brand.Id
                };

                this.data.Toys.Add(toy);

                var toyOrder = new ToyOrder
                {
                    OrderId = orderId,
                    ToyId = toy.Id
                };

                this.data.ToyOrders.Add(toyOrder);

                this.data.SaveChanges();

                Console.WriteLine($"Successfully added {toy.Name} to {brand.Name}");
            }

        }

        public void Remove(string brandName, string toyName, int orderId)
        {
            if (brandName.Length > DataValidation.BrandNameLength)
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(brandName))
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Brands.Any(b => b.Name == brandName))
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NotExistingBrand);
            }

            else if (toyName.Length > DataValidation.ToyNameLength)
            {
                throw new ArgumentException(ExceptionMessages.ToyExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(toyName))
            {
                throw new ArgumentException(ExceptionMessages.ToyExceptions.NameNullOrEmptyException);
            }

            var toy = this.data.Toys
                .FirstOrDefault(t => t.Name == toyName);


            if (this.data.Toys.Any(t => t.Name == toy.Name))
            {
                this.data.Toys.Remove(toy);

                var toyOrder = this.data.ToyOrders
                    .Where(to => to.ToyId == toy.Id && to.OrderId == orderId)
                    .FirstOrDefault();

                this.data.ToyOrders.Remove(toyOrder);

                this.data.SaveChanges();

                Console.WriteLine($"Successfully removed {toy.Name} from {brandName}");
            }
        }

        public void GetObject(string name)
        {
            if (name.Length > DataValidation.ToyNameLength)
            {
                throw new ArgumentException(ExceptionMessages.ToyExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.ToyExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Toys.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.ToyExceptions.NotExistingToy);
            }

            var toy = this.data.Toys
                 .Where(t => t.Name == name)
                 .Select(t => new ToyListingModel
                 {
                     Id = t.Id,
                     Name = t.Name,
                     Description = t.Description,
                     Price = t.Price,
                     BrandName = t.Brand.Name,
                     CategoryName = t.Category.Name
                 })
                 .FirstOrDefault();

            Console.WriteLine($"Toy id: {toy.Id}, toy name: {toy.Name}, toy description: {toy.Description}, " +
                $"toy price: {toy.Price}, toy brand name: {toy.BrandName}, toy category name: {toy.CategoryName}");

        }

        public void GetObjectWithCollections(string name)
        {
            if (name.Length > DataValidation.ToyNameLength)
            {
                throw new ArgumentException(ExceptionMessages.ToyExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.ToyExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Toys.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.ToyExceptions.NotExistingToy);
            }

            var toys = this.data.Toys
                .Where(t => t.Name == name)
                .Select(t => new ToyFullListingModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    Price = t.Price,
                    BrandName = t.Brand.Name,
                    CategoryName = t.Category.Name,
                    Orders = t.Orders
                    .Select(o => new ToyOrderListingModel
                    {
                        OrderId = o.OrderId,
                        OrderName = o.Order.Name,
                        ToyId = o.ToyId,
                        ToyName = o.Toy.Name

                    })
                  .ToList()
                })
                .ToList();

            foreach (var toy in toys)
            {
                Console.WriteLine($"Toy id: {toy.Id}, toy name: {toy.Name}, toy description: {toy.Description}, " +
               $"toy price: {toy.Price}, toy brand name: {toy.BrandName}, toy category name: {toy.CategoryName}");

                Console.WriteLine("Orders:");

                foreach (var order in toy.Orders)
                {
                    Console.WriteLine($"Order id: {order.OrderId}, order name: {order.OrderName}, toy id: {order.ToyId}, " +
                        $"toy name: {order.ToyName}");
                }

            }
        }
    }
}
