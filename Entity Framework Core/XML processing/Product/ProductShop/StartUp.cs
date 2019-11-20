using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<ProductShopProfile>();
            });

            using (var context = new ProductShopContext())
            {
                //db.Database.EnsureCreated();

                //var xmlPath = File.ReadAllText("./../../../Datasets/categories-products.xml");

                string result = GetUsersWithProducts(context);

                Console.WriteLine(result);

            }
        }

        //problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])serializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);

            int count = context.SaveChanges();

            return $"Successfully imported {count}";

        }

        //problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var products = new List<Product>();

            using (var reader = new StringReader(inputXml))
            {
                var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(reader);

                foreach (var productDto in productsDto)
                {
                    var product = Mapper.Map<Product>(productDto);

                    products.Add(product);

                }

            }

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";

        }

        //problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            List<Category> categories = new List<Category>();

            using (var reader = new StringReader(inputXml))
            {
                var categoryDtos = ((ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml)))
                 .Where(c => c.Name != null);

                foreach (var categoryDto in categoryDtos)
                {
                    var category = Mapper.Map<Category>(categoryDto);

                    categories.Add(category);
                }

            }

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[])
                , new XmlRootAttribute("CategoryProducts"));

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            using (var reader = new StringReader(inputXml))
            {
                var categoryProductsDtos = ((ImportCategoryProductDto[])xmlSerializer.Deserialize(reader))
                    .Where(c => context.Categories.Any(cat => cat.Id == c.CategoryId)
                    && context.Products.Any(p => p.Id == c.ProductId));

                foreach (var categoryProductDto in categoryProductsDtos)
                {
                    var categoryProduct = Mapper.Map<CategoryProduct>(categoryProductDto);

                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductsInRangeDto[])
                , new XmlRootAttribute("Products"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        //problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .Select(u => new ExportUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ProductsSold = u.ProductsSold
                    .Select(p => new ExportProductDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserDto[])
                , new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();

        }

        //problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoryDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCategoryDto[])
                , new XmlRootAttribute("Categories"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        //problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                  .OrderByDescending(p => p.ProductsSold.Count())
                .Select(u => new ExportSoldUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductDto
                    {
                        Count = u.ProductsSold.Count(),
                        Products = u.ProductsSold
                        .Select(p => new ExportProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }

                })
                .Take(10)
                .ToArray();

            var userAndProductDto = new ExportUserAndProductDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = users
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserAndProductDto)
                , new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), userAndProductDto, namespaces);

            return sb.ToString().TrimEnd();

        }
    }
}