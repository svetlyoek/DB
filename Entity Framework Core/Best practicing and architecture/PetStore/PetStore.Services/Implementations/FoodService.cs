namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.Food;
    using PetStore.Services.Models.FoodOrder;
    using System;
    using System.Linq;

    public class FoodService : IFoodService
    {

        private readonly PetStoreDbContext data;

        public FoodService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Add(string brandName, string foodName, DateTime expdate, decimal price, double weight, int categoryId, int orderId)

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

            else if (foodName.Length > DataValidation.FoodNameLength)
            {
                throw new ArgumentException(ExceptionMessages.FoodExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(foodName))
            {
                throw new ArgumentException(ExceptionMessages.FoodExceptions.NameNullOrEmptyException);
            }

            else if (price <= 0)
            {
                throw new ArgumentException(ExceptionMessages.FoodExceptions.PriceException);
            }

            else if (weight <= 0)
            {
                throw new ArgumentException(ExceptionMessages.FoodExceptions.WeightException);
            }

            var brand = this.data
                .Brands
                .FirstOrDefault(b => b.Name == brandName);

            if (!this.data.Foods.Any(t => t.Name == foodName))
            {
                var food = new Food
                {
                    Name = foodName,
                    ExpirationDate = expdate,
                    Price = price,
                    Weight = weight,
                    CategoryId = categoryId,
                    BrandId = brand.Id
                };

                this.data.Foods.Add(food);

                var foodOrder = new FoodOrder
                {
                    FoodId = food.Id,
                    OrderId = orderId
                };

                this.data.FoodOrders.Add(foodOrder);

                this.data.SaveChanges();

                Console.WriteLine($"Successfully added {food.Name} to {brand.Name}");
            }
        }

        public void Remove(string brandName, string foodName, int orderId)
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

            else if (foodName.Length > DataValidation.FoodNameLength)
            {
                throw new ArgumentException(ExceptionMessages.FoodExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(foodName))
            {
                throw new ArgumentException(ExceptionMessages.FoodExceptions.NameNullOrEmptyException);
            }

            var food = this.data.Foods
                .FirstOrDefault(f => f.Name == foodName);

            if (this.data.Foods.Any(f => f.Name == food.Name))
            {
                this.data.Foods.Remove(food);

                var foodOrder = this.data.FoodOrders
                    .Where(fo => fo.FoodId == food.Id && fo.OrderId == orderId)
                    .FirstOrDefault();

                this.data.FoodOrders.Remove(foodOrder);

                this.data.SaveChanges();

                Console.WriteLine($"Successfully removed {food.Name} from {brandName}");
            }
        }

        public void GetObject(string name)
        {
            if (name.Length > DataValidation.BrandNameLength)
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Foods.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.FoodExceptions.NotExistingFood);
            }

            var food = this.data.Foods
                 .Where(f => f.Name == name)
                 .Select(f => new FoodListingModel
                 {
                     Id = f.Id,
                     Name = f.Name,
                     ExpirationDate = f.ExpirationDate,
                     Price = f.Price,
                     Weight = f.Weight,
                     BrandName = f.Brand.Name,
                     CategoryName = f.Category.Name
                 })
                 .FirstOrDefault();

            Console.WriteLine($"Food id: {food.Id}, food name: {food.Name}, food expiration date: {food.ExpirationDate}, " +
                $"food price: {food.Price}, food weight: {food.Weight}, food brand name: {food.BrandName}, " +
                $"food category name: {food.CategoryName}");

        }

        public void GetObjectWithCollections(string name)
        {
            if (name.Length > DataValidation.BrandNameLength)
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Foods.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.FoodExceptions.NotExistingFood);
            }

            var foods = this.data.Foods
                .Where(f => f.Name == name)
                .Select(f => new FoodFullListingModel
                {
                    Id = f.Id,
                    Name = f.Name,
                    ExpirationDate = f.ExpirationDate,
                    Price = f.Price,
                    Weight = f.Weight,
                    BrandName = f.Brand.Name,
                    CategoryName = f.Category.Name,
                    Orders = f.Orders
                    .Select(fo => new FoodOrderListingModel
                    {
                        FoodId = fo.FoodId,
                        FoodName = fo.Food.Name,
                        OrderId = fo.OrderId,
                        OrderName = fo.Order.Name
                    })
                  .ToList()
                })
                .ToList();

            foreach (var food in foods)
            {
                Console.WriteLine($"Food id:{food.Id}, food name: {food.Name}, food expiraton date: {food.ExpirationDate}, " +
                    $"food price: {food.Price}, food weight: {food.Weight}, food brand name: {food.BrandName}, " +
                    $"food category name: {food.CategoryName}");

                Console.WriteLine("Orders:");

                foreach (var order in food.Orders)
                {
                    Console.WriteLine($"Food id: {order.FoodId}, food name: {order.FoodName}, order id: {order.OrderId}, " +
                        $"order name: {order.OrderName}");
                }

            }
        }
    }
}

