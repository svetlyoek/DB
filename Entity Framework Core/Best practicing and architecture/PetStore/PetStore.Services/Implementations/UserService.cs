namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.Order;
    using PetStore.Services.Models.User;
    using System;
    using System.Linq;

    public class UserService : IUserService
    {
        public readonly PetStoreDbContext data;

        public UserService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Add(string name, string email)
        {
            if (name.Length > DataValidation.UserNameLength)
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.NameNullOrEmptyException);
            }

            else if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.EmailNullOrWhiteSpaceException);
            }

            else if (email.Length > DataValidation.UserEmailLength)
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.EmailLengthException);
            }

            else if (this.data.Users.Any(b => b.FullName == name))
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.ExistingUserException);
            }

            var user = new User
            {
                FullName = name,
                Email = email
            };

            this.data.Users.Add(user);

            this.data.SaveChanges();

            Console.WriteLine($"{user.FullName} successfully added in the database.");

        }

        public void Remove(string name)
        {
            if (name.Length > DataValidation.BrandNameLength)
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Users.Any(b => b.FullName == name))
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.NotExistingUserException);
            }

            var user = this.data
                .Users
                .FirstOrDefault(b => b.FullName == name);

            this.data.Users.Remove(user);

            this.data.SaveChanges();

            Console.WriteLine($"{user.FullName} successfully removed from the database.");
        }

        public void GetObject(string name)
        {
            if (name.Length > DataValidation.UserNameLength)
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Users.Any(b => b.FullName == name))
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.NotExistingUserException);
            }

            var user = this.data.Users
                 .Where(u => u.FullName == name)
                 .Select(u => new UserListingModel
                 {
                     Id = u.Id,
                     Name = u.FullName,
                     Email = u.Email
                 })
                 .FirstOrDefault();

            Console.WriteLine($"User id: {user.Id}, user name: {user.Name}, user email: {user.Email}");
        }

        public void GetObjectWithCollections(string name)
        {
            if (name.Length > DataValidation.UserNameLength)
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Users.Any(b => b.FullName == name))
            {
                throw new ArgumentException(ExceptionMessages.UserExceptions.NotExistingUserException);
            }

            var users = this.data.Users
                .Where(u => u.FullName == name)
                .Select(u => new UserFullListingModel
                {
                    Id = u.Id,
                    Name = u.FullName,
                    Email = u.Email,
                    Orders = u.Orders
                    .Select(o => new OrderListingModel
                    {
                        Id = o.Id,
                        DateOfPurchase = o.DateOfPurchase,
                        Description = o.Description,
                        Name = o.Name,
                        Type = o.OrderType.ToString(),
                        UserName = o.Name

                    })
                  .ToList()
                })
                .ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"User id: {user.Id}, user name: {user.Name}, user email: {user.Email}");

                Console.WriteLine("Orders:");

                foreach (var order in user.Orders)
                {
                    Console.WriteLine($"Order id:{order.Id}, order name: {order.Name}, order purchase date: {order.DateOfPurchase}, " +
                    $"order type: {order.Type},order description: {order.Description}, order user name: {order.UserName}");
                }

            }
        }


    }
}
