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
                foreach (var course in context.Courses.OfType<OnsiteCourse>())
                {
                    Console.WriteLine("{0} {1}",
                        course.Title, course.Location);
                }

                foreach (var course in context.Courses.OfType<OnlineCourse>())
                {
                    Console.WriteLine("{0} {1}", 
                        course.Title, course.URL);
                }
                
            }
        }
    }
}
