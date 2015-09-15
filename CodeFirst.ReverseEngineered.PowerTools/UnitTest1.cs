using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirst.ReverseEngineered.PowerTools.Models;

namespace CodeFirst.ReverseEngineered.PowerTools
{
    [TestClass]
    public class UnitTest1
    {
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
    }
}
