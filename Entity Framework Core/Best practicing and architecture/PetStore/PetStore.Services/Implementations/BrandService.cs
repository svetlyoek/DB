namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.Brand;
    using PetStore.Services.Models.Food;
    using PetStore.Services.Models.Toy;
    using System;
    using System.Linq;

    public class BrandService : IBrandService
    {
        private readonly PetStoreDbContext data;

        public BrandService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Add(string name)
        {
            if (name.Length > DataValidation.BrandNameLength)
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NameNullOrEmptyException);
            }

            else if (this.data.Brands.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.ExistingBrand);
            }

            var brand = new Brand
            {
                Name = name
            };

            this.data.Brands.Add(brand);

            this.data.SaveChanges();

            Console.WriteLine($"{brand.Name} successfully added in the database.");

        }


        public void Remove(string name)
        {
            if (name.Length > DataValidation.BrandNameLength)
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Brands.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NotExistingBrand);
            }

            var brand = this.data
                .Brands
                .FirstOrDefault(b => b.Name == name);

            this.data.Brands.Remove(brand);

            this.data.SaveChanges();

            Console.WriteLine($"{brand.Name} successfully removed from the database.");
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

            else if (!this.data.Brands.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NotExistingBrand);
            }

            var brand = this.data.Brands
                 .Where(b => b.Name == name)
                 .Select(b => new BrandListingModel
                 {
                     Id = b.Id,
                     Name = b.Name
                 })
                 .FirstOrDefault();

            Console.WriteLine($"Brand: Id-{brand.Id}, name-{brand.Name}");

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

            else if (!this.data.Brands.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.BrandExceptions.NotExistingBrand);
            }

            var brands = this.data.Brands
                .Where(b => b.Name == name)
                .Select(b => new BrandFullListingModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Toys = b.Toys
                    .Select(t => new ToyListingModel
                    {

                        Id = t.Id,
                        Name = t.Name,
                        Description = t.Description,
                        Price = t.Price,
                        BrandName = t.Brand.Name,
                        CategoryName = t.Category.Name

                    })
                    .ToList(),
                    Foods = b.Foods
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
                    .ToList()

                })
                .ToList();

            foreach (var brand in brands)
            {
                Console.WriteLine($"Brand id:{brand.Id}, brand name: {brand.Name}");
                Console.WriteLine("Toys:");

                foreach (var toy in brand.Toys)
                {
                    Console.WriteLine($"Toy id: {toy.Id}, toy name: {toy.Name}, toy description: {toy.Description}, " +
                        $"toy price: {toy.Price}, toy brand name: {toy.BrandName}, toy category name: {toy.CategoryName}");
                }

                Console.WriteLine("Foods:");

                foreach (var food in brand.Foods)
                {
                    Console.WriteLine($"Food id: {food.Id}, food name: {food.Name}, food expiration date: {food.ExpirationDate}, " +
                        $"food price: {food.Price}, food weight: {food.Weight}, food brand name: {food.BrandName}, " +
                        $"food category name: {food.CategoryName}");
                }
            }
        }


    }
}
