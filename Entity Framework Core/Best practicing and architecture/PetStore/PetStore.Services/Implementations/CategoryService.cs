namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.Category;
    using PetStore.Services.Models.Food;
    using PetStore.Services.Models.Pet;
    using PetStore.Services.Models.Toy;
    using System;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        private readonly PetStoreDbContext data;

        public CategoryService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Add(string name)
        {
            if (name.Length > DataValidation.CategoryNameLength)
            {
                throw new ArgumentException(ExceptionMessages.CategoryExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.CategoryExceptions.NameNullOrEmptyException);
            }

            else if (this.data.Categories.Any(c => c.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.CategoryExceptions.ExistingCategory);
            }

            var category = new Category
            {
                Name = name
            };

            this.data.Categories
                .Add(category);

            this.data.SaveChanges();

            Console.WriteLine($"Successfully added {category.Name} to the database.");
        }


        public void Remove(string name)
        {
            if (name.Length > DataValidation.CategoryNameLength)
            {
                throw new ArgumentException(ExceptionMessages.CategoryExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.CategoryExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Categories.Any(c => c.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.CategoryExceptions.NotExistingCategory);
            }

            var category = this.data.Categories
                .FirstOrDefault(c => c.Name == name);

            this.data.Categories.Remove(category);

            this.data.SaveChanges();

            Console.WriteLine($"{category.Name} successfully removed for the database.");
        }

        public void GetObject(string name)
        {
            if (name.Length > DataValidation.CategoryNameLength)
            {
                throw new ArgumentException(ExceptionMessages.CategoryExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.CategoryExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Categories.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.CategoryExceptions.NotExistingCategory);
            }

            var category = this.data.Categories
                 .Where(b => b.Name == name)
                 .Select(b => new CategoryListingModel
                 {
                     Id = b.Id,
                     Name = b.Name,
                     Description = b.Description

                 })
                 .FirstOrDefault();

            Console.WriteLine($"Category: Id-{category.Id}, Name-{category.Name}");

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

            else if (!this.data.Categories.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.CategoryExceptions.NotExistingCategory);
            }

            var categories = this.data.Categories
                .Where(c => c.Name == name)
                .Select(c => new CategoryFullListingModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Foods = c.Foods
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
                    .ToList(),
                    Toys = c.Toys
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
                    Pets = c.Pets
                    .Select(p => new PetListingModel
                    {
                        Id = p.Id,
                        Birthdate = p.Birthdate,
                        Gender = p.Gender.ToString(),
                        Description = p.Description,
                        Price = p.Price,
                        BreedName = p.Breed.Name,
                        CategoryName = p.Category.Name,
                        OrderId = p.Order.Id
                    })
                    .ToList()

                })
                .ToList();

            foreach (var category in categories)
            {
                Console.WriteLine($"Category id: {category.Id}, category name: {category.Name}, category description: " +
                    $"{category.Description}");

                Console.WriteLine("Foods:");

                foreach (var food in category.Foods)
                {
                    Console.WriteLine($"Food id: {food.Id}, food name: {food.Name}, food expiration date: {food.ExpirationDate}, " +
                        $"food price: {food.Price}, food weight: {food.Weight}, food brand name: {food.BrandName}, " +
                        $"food category name: {food.CategoryName}");
                }

                Console.WriteLine("Toys:");

                foreach (var toy in category.Toys)
                {
                    Console.WriteLine($"Toy id: {toy.Id}, toy name: {toy.Name}, toy description: {toy.Description}, " +
                        $"toy price: {toy.Price}, toy brand name: {toy.BrandName}, " +
                        $"toy category name: {toy.CategoryName}");
                }

                Console.WriteLine("Pets:");

                foreach (var pet in category.Pets)
                {
                    Console.WriteLine($"Pet id: {pet.Id}, pet birthdate: {pet.Birthdate}, pet gender: {pet.Gender}, " +
                        $"pet description: {pet.Description}, pet price: {pet.Price}, pet breed: {pet.BreedName}, " +
                        $"pet category: {pet.CategoryName}, pet order: {pet.OrderId}");
                }
            }
        }
    }
}

