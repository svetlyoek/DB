using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureCreated();

                //var json = File.ReadAllText("./../../../Datasets/sales.xml");

                string result = GetSalesWithAppliedDiscount(db);

                Console.WriteLine(result);
            }

        }

        //problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[])
                , new XmlRootAttribute("Suppliers"));

            var suppliersDto = (ImportSupplierDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliersToAdd = new List<Supplier>();

            foreach (var supplier in suppliersDto)
            {
                var supplierToAdd = Mapper.Map<Supplier>(supplier);

                suppliersToAdd.Add(supplierToAdd);
            }

            context.Suppliers.AddRange(suppliersToAdd);

            context.SaveChanges();

            return $"Successfully imported {suppliersToAdd.Count}";

        }

        //problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]),
                new XmlRootAttribute("Parts"));

            var partsToAdd = new List<Part>();

            var partsDto = (ImportPartDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            foreach (var part in partsDto)
            {
                if (context.Suppliers
                    .Any(s => s.Id == part.SupplierId))
                {
                    var partToAdd = Mapper.Map<Part>(part);

                    partsToAdd.Add(partToAdd);
                }

            }

            context.Parts.AddRange(partsToAdd);

            context.SaveChanges();

            return $"Successfully imported {partsToAdd.Count}";
        }

        //problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]),
                new XmlRootAttribute("Cars"));

            var carsToAdd = new List<Car>();

            var carsDto = (ImportCarDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            foreach (var carDto in carsDto)
            {
                var carToAdd = Mapper.Map<Car>(carDto);

                context.Cars.Add(carToAdd);

                foreach (var part in carDto.Parts.PartsId)
                {
                    if (carToAdd.PartCars.FirstOrDefault(p => p.PartId == part.PartId) == null
                         && context.Parts.Find(part.PartId) != null)
                    {
                        var partCar = new PartCar()
                        {
                            PartId = part.PartId,
                            CarId = carToAdd.Id
                        };

                        carToAdd.PartCars.Add(partCar);
                    }
                }

                carsToAdd.Add(carToAdd);
            }

            context.SaveChanges();


            return $"Successfully imported {carsToAdd.Count}";
        }

        //problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                new XmlRootAttribute("Customers"));

            var customersToAdd = new List<Customer>();

            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            foreach (var customerDto in customersDto)
            {
                var customer = Mapper.Map<Customer>(customerDto);

                customersToAdd.Add(customer);
            }

            context.Customers.AddRange(customersToAdd);

            context.SaveChanges();

            return $"Successfully imported {customersToAdd.Count}";
        }

        //problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSalesDto[]),
                new XmlRootAttribute("Sales"));

            var salesToAdd = new List<Sale>();

            var salesDto = (ImportSalesDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            foreach (var saleDto in salesDto)
            {
                if (context.Cars.Find(saleDto.CarId) != null)
                {
                    var sale = Mapper.Map<Sale>(saleDto);

                    salesToAdd.Add(sale);

                }

            }

            context.Sales.AddRange(salesToAdd);

            context.SaveChanges();

            return $"Successfully imported {salesToAdd.Count}";
        }

        //problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new ExportCarDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarDto[]),
                new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var currentMake = "BMW";

            var cars = context.Cars
                .Where(c => c.Make == currentMake)
                .Select(c => new ExportCarsBmwDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsBmwDto[]),
                new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();

        }

        //problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    ParstCount = s.Parts.Count
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSupplierDto[]),
                new XmlRootAttribute("suppliers"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();

        }

        //problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsParts = context.Cars
                .Select(c => new ExportCarsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                    .Select(p => new ExportPartsDto
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price

                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()

                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsDto[]),
                new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), carsParts, namespaces);

            return sb.ToString().TrimEnd();

        }

        //problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new ExportCustomerDto
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomerDto[]),
                new XmlRootAttribute("customers"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();

        }

        //problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new ExportSaleDto
                {
                    Car = new ExportCarsDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },

                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(p => p.Part.Price) -
                    s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSaleDto[]),
                new XmlRootAttribute("sales"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), sales, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}