using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureCreated();

                //var json = File.ReadAllText("./../../../Datasets/categories-products.json");

                string result = GetUsersWithProducts(db);

                Console.WriteLine(result);
            }
        }

        //problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        //problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        //problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null);

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoriesProducts);

            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        //problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        //problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(ps => ps.Buyer != null)
                        .Select(sp => new
                        {
                            sp.Name,
                            sp.Price,
                            BuyerFirstName = sp.Buyer.FirstName,
                            BuyerLastName = sp.Buyer.LastName
                        })
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var usersJson = JsonConvert.SerializeObject(users, Formatting.Indented, jsonSettings);

            return usersJson;

        }

        //problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = $"{c.CategoryProducts.Average(p => p.Product.Price):f2}",
                    totalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):f2}"
                })
                .OrderByDescending(c => c.productsCount)
                .ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        //problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(b => b.Buyer != null),
                        products = u.ProductsSold
                        .Where(b => b.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                    }
                })
                .ToList();

            var filteredUsers = new
            {
                usersCount = users.Count,
                users = users
            };

            var json = JsonConvert.SerializeObject(filteredUsers, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }
    }
}