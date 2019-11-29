namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Models.Enums;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.FoodOrder;
    using PetStore.Services.Models.Order;
    using PetStore.Services.Models.Pet;
    using PetStore.Services.Models.ToyOrder;
    using System;
    using System.Linq;

    public class OrderService : IOrderService
    {
        private readonly PetStoreDbContext data;

        public OrderService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Add(string name, int userId)
        {
            if (name.Length > DataValidation.OrderNameLength)
            {
                throw new ArgumentException(ExceptionMessages.OrderExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.OrderExceptions.NameNullOrEmptyException);
            }

            else if (this.data.Orders.Any(o => o.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.OrderExceptions.ExistingOrderException);
            }

            var order = new Order
            {
                Name = name,
                DateOfPurchase = DateTime.Now,
                OrderType = OrderType.Processing,
                UserId = userId

            };

            this.data.Orders.Add(order);

            this.data.SaveChanges();

            Console.WriteLine($"Order with id {order.Id} successfully added in the database.");

        }


        public void Remove(string name)
        {
            if (name.Length > DataValidation.OrderNameLength)
            {
                throw new ArgumentException(ExceptionMessages.OrderExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.OrderExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Orders.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.OrderExceptions.NotExistingOrderException);
            }

            var order = this.data.Orders
                .FirstOrDefault(f => f.Name == name);

            if (this.data.Orders.Any(f => f.Name == order.Name))
            {
                this.data.Orders.Remove(order);


                this.data.SaveChanges();

                Console.WriteLine($"Successfully removed {order.Name}");
            }
        }

        public void GetObject(string name)
        {
            if (name.Length > DataValidation.OrderNameLength)
            {
                throw new ArgumentException(ExceptionMessages.OrderExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.OrderExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Orders.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.OrderExceptions.NotExistingOrderException);
            }

            var order = this.data.Orders
                 .Where(o => o.Name == name)
                 .Select(o => new OrderListingModel
                 {
                     Id = o.Id,
                     Name = o.Name,
                     DateOfPurchase = o.DateOfPurchase,
                     Type = o.OrderType.ToString(),
                     Description = o.Description,
                     UserName = o.User.FullName
                 })
                 .FirstOrDefault();

            Console.WriteLine($"Order id: {order.Id}, order name: {order.Name}, order purchase date: {order.DateOfPurchase}, " +
                $"order type: {order.Type}, order description: {order.Description}, order user name: {order.UserName}");


        }

        public void GetObjectWithCollections(string name)
        {
            if (name.Length > DataValidation.OrderNameLength)
            {
                throw new ArgumentException(ExceptionMessages.OrderExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.OrderExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Orders.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.OrderExceptions.NotExistingOrderException);
            }

            var orders = this.data.Orders
                .Where(o => o.Name == name)
                .Select(o => new OrderFullListingModel
                {
                    Id = o.Id,
                    Name = o.Name,
                    DateOfPurchase = o.DateOfPurchase,
                    Type = o.OrderType.ToString(),
                    Description = o.Description,
                    UserName = o.User.FullName,
                    Pets = o.Pets
                    .Select(p => new PetFullListingModel
                    {
                        Id = p.Id,
                        Birthdate = p.Birthdate,
                        BreedName = p.Breed.Name,
                        CategoryName = p.Category.Name,
                        Description = p.Description,
                        Gender = p.Gender.ToString(),
                        OrderId = p.OrderId,
                        Price = p.Price
                    })
                  .ToList(),
                    Foods = o.Foods
                   .Select(fo => new FoodOrderListingModel
                   {
                       FoodId = fo.FoodId,
                       OrderId = fo.OrderId,
                       FoodName = fo.Food.Name,
                       OrderName = fo.Order.Name
                   })
                   .ToList(),
                    Toys = o.Toys
                   .Select(to => new ToyOrderListingModel
                   {
                       OrderId = to.OrderId,
                       OrderName = to.Order.Name,
                       ToyId = to.ToyId,
                       ToyName = to.Toy.Name

                   })
                   .ToList()
                })
                .ToList();

            foreach (var order in orders)
            {
                Console.WriteLine($"Order id:{order.Id}, order name: {order.Name}, order purchase date: {order.DateOfPurchase}, " +
                    $"order type: {order.Type},order description: {order.Description}, order user name: {order.UserName}");

                Console.WriteLine("Pets:");

                foreach (var pet in order.Pets)
                {
                    Console.WriteLine($"Pet id: {pet.Id}, pet birthdate: {pet.Birthdate}, pet breed name: {pet.BreedName}, " +
                        $"pet category name: {pet.CategoryName}, pet description: {pet.Description}, pet gender: {pet.Gender}, " +
                        $"pet order id: {pet.OrderId}, pet price: {pet.Price}");
                }

                Console.WriteLine("Foods:");

                foreach (var food in order.Foods)
                {
                    Console.WriteLine($"Food id: {food.FoodId}, order id: {food.OrderId}, food name: {food.FoodName}, " +
                        $"order name: {food.OrderId}");
                }

                Console.WriteLine("Toys:");

                foreach (var toy in order.Toys)
                {
                    Console.WriteLine($"Order id: {toy.OrderId}, order name: {toy.OrderName}, toy id: {toy.ToyId}, " +
                        $"toy name: {toy.ToyName}");
                }

            }
        }
    }
}
