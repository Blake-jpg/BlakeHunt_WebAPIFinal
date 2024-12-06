using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlakeHunt_WebAPI_Final.Models.customers;
using BlakeHunt_WebAPI_Final.Models.orders;
using BlakeHunt_WebAPI_Final.Models.Products;

namespace BlakeHunt_WebAPI_Final.Data
{
    public class CustomersdbContext : DbContext
    {
        public CustomersdbContext (DbContextOptions<CustomersdbContext> options)
            : base(options)
        {
        }

        public DbSet<BlakeHunt_WebAPI_Final.Models.customers.Customer> Costomers { get; set; } = default!;
        public DbSet<BlakeHunt_WebAPI_Final.Models.orders.Order> Orders { get; set; } = default!;
        public DbSet<BlakeHunt_WebAPI_Final.Models.customers.Phone> Phone { get; set; } = default!;
        public DbSet<BlakeHunt_WebAPI_Final.Models.customers.Address> Address { get; set; } = default!;
        public DbSet<BlakeHunt_WebAPI_Final.Models.Products.Product> Products { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                //i don't know how to seed ICollection :(
                {
                    CustId = 1,
                    FirstName = "Gohn",
                    LastName = "Zmith"
                },
                new Customer
                {
                    CustId = 2,
                    FirstName = "Janice",
                    LastName = "1"
                },
                new Customer
                {
                    CustId = 3,
                    FirstName = "peith",
                    LastName = "lowercase"
                }
            );
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    AddressId = 1,
                    StreetAdress = "322 Gwen Street",
                    City = "Tenino",
                    State = "idk",
                    Country = "United States",
                    CustId = 3
                },
                new Address
                {
                    AddressId = 2,
                    StreetAdress = "556 Garb Rd",
                    City = "London",
                    Country = "United Kingdom",
                    CustId  = 2
                },
                new Address
                {
                    AddressId = 3,
                    StreetAdress = "239 Silver Street",
                    City = "Centralia",
                    State = "Washinton",
                    Country = "United States",
                    CustId = 3
                }
            );
            modelBuilder.Entity<Phone>().HasData(
                new Phone
                {
                    PhoneId = 1,
                    PhoneNumber = "564-555-2535",
                    CustId = 1
                },
                new Phone
                {
                    PhoneId = 2,
                    PhoneNumber = "020-555-2745",
                    CustId = 2
                },
                new Phone
                {
                    PhoneId = 3,
                    PhoneNumber = "360-555-5764",
                    CustId = 3
                }
            );

            //Orders
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = 1,
                    Total = 500.00,
                    //migrations
                },
                new Order
                {
                    OrderId = 2,
                    Total = 95.00
                },
                new Order
                {
                    OrderId = 3,
                    Total = 44.45
                }
            );

            //Products
            modelBuilder.Entity<Product>().HasData(
                    new Product 
                    {
                        ProductID = 1,
                        ProductName = "shirt",
                        Price = 10.00,
                        ProductDescription = "shirt"
                    },
                    new Product
                    {
                        ProductID = 2,
                        ProductName = "pair of pant",
                        Price = 20.00,
                        ProductDescription = "pants"
                    },
                    new Product
                    {
                        ProductID = 3,
                        ProductName = "shoes",
                        Price = 45.00,
                        ProductDescription = "for feet"
                    }
            );

        }
    }
}
