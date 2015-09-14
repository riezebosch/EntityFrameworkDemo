using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EntityFrameworkDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new SchoolEntities())
            {
                foreach (var course in context.Courses)
                {
                    Console.WriteLine("{0} {1}", course.Title, course.OnlineCourse?.URL);
                }
                
            }
        }
    }
}
