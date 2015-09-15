using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EntityFramework.CodeFirst
{
    [TestClass]
    public class UnitTest1
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<TailSpinToysContext>());
        }

        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new TailSpinToysContext())
            {
                context.Toys.Add(new Toy { Name = "Helicopter", Price = 5m });
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void ShowMeTheDefaultTPH()
        {
            using (var context = new TailSpinToysContext())
            {
                context.Toys.Add(new ExpensiveToy { Name = "Gold Plated Helicopter", Price = 500m, Commission = 3 });
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void DemoVanForeignKeyRelaties()
        {
            using (var context = new TailSpinToysContext())
            {
                context.Toys.Add(new ExpensiveToy
                {
                    Name = "Gold Plated Helicopter",
                    Price = 500m,
                    Commission = 3,
                    Supplier = new Supplier
                    {
                        Name = "Fisherprice",
                        Address = new Address
                        {
                            City = "Birmingham",
                            Zip = "1234"
                        }
                    }
                });
                context.SaveChanges();
            }

        }

        [TestMethod]
        public void DemoVanVeelOpVeelRelatie()
        {
            using (var context = new TailSpinToysContext())
            {
                var store = new Store
                {
                    Name = "Bart Smit",
                    Address = new Address
                    {
                        City = "Veenendaal",
                        Zip = "3906LE"
                    },

                };

                var supplier = new Supplier
                {
                    Name = "Fisherprice",
                    Address = new Address
                    {
                        City = "Birmingham",
                        Zip = "1234"
                    },

                    Stores = new List<Store> { store }
                };

                store.Suppliers = new List<Supplier> { supplier };
                context.Stores.Add(store);

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void DemoVanConcurrencyAttribute()
        {
            using (var context = new TailSpinToysContext())
            {
                context.Toys.Add(new Toy
                {
                    Name = "Lego", Price = 19.99m
                });

                context.SaveChanges();

                Thread.Sleep(15000);
                var toy = context.Toys.First();
                toy.Name = "Lego City";

                context.SaveChanges();
            }


        }
    }
}
