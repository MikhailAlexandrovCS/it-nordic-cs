using DemoApp_EF.Data;
using DemoApp_EF.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DemoApp_EF
{
    class Program
    {
        private static OnlineStoreContext _context = new OnlineStoreContext();

        static void Main(string[] args)
        {
            //InsertCustomers();
            //InsertProduct();
            //SelectCustomers();
            //Console.ReadKey();
            //MoreQueries();
            //UpdateCustomers();
            //UpdateProductDisconnected();
            DeleteCustomers();
        }

        private static void DeleteCustomers()
        {
            //var customer = _context.Customers.First(c => c.Id == 1);
            var customer = new Customer { Id = 1 };
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        private static void UpdateProductDisconnected()
        {
            //var product = _context.Products.First();
            //product.Price *= 0.1M;

            var product = new Product
            {
                Id = 1,
                Name = "Bread",
                Price = 10M - 10M * 0.1M
            };

            using (var newContext = new OnlineStoreContext())
            {
                newContext.Products.Update(product);
                newContext.SaveChanges();
            }
        }

        private static void UpdateCustomers()
        {
            var customer = _context.Customers.First();
            customer.Name = "Mr." + customer.Name;
            _context.SaveChanges();
        }

        private static void MoreQueries()
        {
            //var customers = _context.Customers
            //    .OrderBy(c => c.Id)
            //    .Last(c => c.Name.Length > 6);

            //_context.Products.Add(new Product { Name = "Cake", Price = 2140 });
            //_context.SaveChanges();

            var products = _context.Products
                .Where(p => EF.Functions.Like(p.Name , "ca%e"))
                .ToList();

            foreach (var product in products)
                Console.WriteLine($"{product.Name} {product.Id}: {product.Price}");
        }

        private static void SelectCustomers()
        {
            using (var context = new OnlineStoreContext())
            {
                string name = "Mikhail";
                //var allCustomers = context.Customers
                //    .Where(c => c.Name == name)
                //    .ToList();
                var customers = context.Customers.ToList();
                foreach (var customer in customers)
                    Console.WriteLine($"Customer: {customer.Name} has id: {customer.Id}");
            }
        }

        private static void InsertProduct()
        {
            var product = new Product { Name = "Bread", Price = 10 };
            var productSet = new Product[]
            {
                new Product{Name = "Milk", Price = 62},
                new Product{Name = "Cheese", Price = 39}
            };

            using (var context = new OnlineStoreContext())
            {
                context.Products.Add(product);
                context.Products.AddRange(productSet);
                context.SaveChanges();
            }
        }

        private static void InsertCustomers()
        {
            var customer = new Customer { Name = "Mikhail2" };
            //_context.Add(customer);
            //var customerSet = new Customer[]
            //{
            //    new Customer { Name = "Nikolay" },
            //    new Customer {Name = "Vladislav"}
            //};

            using (var context = new OnlineStoreContext())
            {
                //context.Customers.Add(customer);
                context.Add(customer);
                //context.AddRange(customerSet);
                //context.SaveChanges();
            }
        }
    }
}
