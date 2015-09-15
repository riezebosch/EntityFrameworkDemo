using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFirst.ReverseEngineered.ReversePocoGenerator
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Entity Framework Reverse POCO Generator:
        ///   https://visualstudiogallery.msdn.microsoft.com/ee4fcff9-0c4c-4179-afd9-7a2fb90f5838
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
    }
}
