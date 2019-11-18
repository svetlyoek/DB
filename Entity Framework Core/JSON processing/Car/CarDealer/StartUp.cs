namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTO;
    using CarDealer.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //string json = File.ReadAllText("./../../../Datasets/sales.json");

                string result = GetSalesWithAppliedDiscount(db);

                Console.WriteLine(result);
            }
        }

        //problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        //problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId));

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        //problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<ImortCarDto[]>(inputJson);

            foreach (var carDto in json)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDto.PartsId)
                {
                    PartCar partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(p => p.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {json.Count()}.";
        }

        //problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        //problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";


        }

        //problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var currentMake = "Toyota";

            var cars = context.Cars
                .Where(c => c.Make == currentMake)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = currentMake,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        //problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new ExportCarDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },

                    parts = c.PartCars
                    .Select(p => new ExportPartDto
                    {
                        Name = p.Part.Name,
                        Price = $"{p.Part.Price:f2}"
                    })
                    .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;

        }

        //problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var sales = context.Customers
                .Where(c => c.Sales.Count() >= 1)
                .Select(c => new ExportCustomerDto
                {
                    Fullname = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales
                    .Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(m => m.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }

        //problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                 .Select(s => new
                 {
                     car = new ExportCarDto
                     {
                         Make = s.Car.Make,
                         Model = s.Car.Model,
                         TravelledDistance = s.Car.TravelledDistance
                     },
                     customerName = s.Customer.Name,
                     Discount = $"{s.Discount:F2}",
                     price = $"{s.Car.PartCars.Sum(p => p.Part.Price):F2}",
                     priceWithDiscount = $@"{(s.Car.PartCars.Sum(p => p.Part.Price) -
                         s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100):F2}"
                 })
                 .Take(10)
                 .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
    }
}