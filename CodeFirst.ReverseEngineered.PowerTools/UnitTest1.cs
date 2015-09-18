using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirst.ReverseEngineered.PowerTools.Models;
using System.Linq;
using System.Data.Entity;
using CodeFirst.ReverseEngineered.PowerTools.Migrations;
using System.Transactions;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace CodeFirst.ReverseEngineered.PowerTools
{
    [TestClass]
    public class UnitTest1
    {
        TransactionScope _scope;

        [TestInitialize]
        public void TestInit() => _scope = new TransactionScope();

        [TestCleanup]
        public void TestCleanup() => _scope.Dispose();

        [ClassInitialize]
        public static void ClassInit(TestContext tc)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolContext, Configuration>());
            using (var context = new SchoolContext())
            {
                context.Database.Initialize(true);
            }
        }

        /// <summary>
        /// Power Tools hack for VS2015 by Julie Lerman:
        ///   http://thedatafarm.com/data-access/installing-ef-power-tools-into-vs2015/
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new SchoolContext())
            {
                foreach (var p in context.People)
                {
                    Console.WriteLine($"{p.FirstName} {p.LastName}");
                }
            }
        }

        [TestMethod]
        public void VoorbeeldVanMigration()
        {
            using (var context = new SchoolContext())
            {
                Assert.IsTrue(context.People.OfType<Student>().Any(s => s.FirstName == "Gytis"));

            }
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void VoorbeeldVanConcurrency()
        {
            using (var ctx1 = new SchoolContext())
            using (var ctx2 = new SchoolContext())
            {
                var p1 = ctx1.People.Find(14);
                p1.FirstName = "Demo1";

                var p2 = ctx2.People.Find(14);
                p2.FirstName = "Demo2";

                ctx1.SaveChanges();
                ctx2.SaveChanges();
            }
        }

        [TestMethod]
        public void VoorbeeldVanConcurrency_Client2Wint()
        {
            using (var ctx1 = new SchoolContext())
            using (var ctx2 = new SchoolContext())
            {
                ctx2.Database.Log = Console.WriteLine;

                var p1 = ctx1.People.Find(14);
                p1.FirstName = "Demo1";

                var p2 = ctx2.People.Find(14);
                p2.FirstName = "Demo2";

                ctx1.SaveChanges();

                try
                {
                    ctx2.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var entry = ex.Entries.First();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());

                    ctx2.SaveChanges();
                }
            }


            using (var ctx = new SchoolContext())
            {
                var p = ctx.People.Find(14);
                Assert.AreEqual("Demo2", p.FirstName);
            }
        }

        [TestMethod]
        public void VoorbeeldVanConcurrency_Client2Verliest()
        {
            using (var ctx1 = new SchoolContext())
            using (var ctx2 = new SchoolContext())
            {
                ctx2.Database.Log = Console.WriteLine;

                var p1 = ctx1.People.Find(14);
                p1.FirstName = "Demo1";

                var p2 = ctx2.People.Find(14);
                p2.FirstName = "Demo2";

                var p3 = ctx2.People.Find(15);
                p3.FirstName = "YetAnotherChange";

                ctx1.SaveChanges();

                try
                {
                    ctx2.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var entry = ex.Entries.First();
                    entry.Reload();

                    ctx2.SaveChanges();
                }
            }


            using (var ctx = new SchoolContext())
            {
                var p2 = ctx.People.Find(14);
                Assert.AreEqual("Demo1", p2.FirstName);

                var p3 = ctx.People.Find(15);
                Assert.AreEqual("YetAnotherChange", p3.FirstName);

            }
        }

        [TestMethod]
        public async Task TestVanAsyncMetTransactions()
        {
            var trans = new TransactionScope(TransactionScopeOption.RequiresNew,
                TransactionScopeAsyncFlowOption.Enabled);

            using (var context = new SchoolContext())
            {
                var p = context.People.Find(1);
                p.FirstName = "TEST";

                await context.SaveChangesAsync();
                trans.Dispose();

                using (new TransactionScope(TransactionScopeOption.RequiresNew))
                using (var ctx2 = new SchoolContext())
                {
                    var p2 = ctx2.People.Find(1);
                    Assert.AreNotEqual("TEST", p2.FirstName);
                }
            }


        }
    }
}