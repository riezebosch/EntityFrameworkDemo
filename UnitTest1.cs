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
                    Console.WriteLine($"{course.Title} {course.Location}");
                }

                foreach (var course in context.Courses.OfType<OnlineCourse>())
                {
                    Console.WriteLine($"{course.Title} {course.URL}");
                }
                
            }
        }

        [TestMethod]
        public void TablePerHierarchyOnPerson()
        {
            using (var context = new SchoolEntities())
            {
                Console.WriteLine("-- Professors: ");
                foreach (var person in context.People.OfType<Professor>())
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName} ({person.HireDate})");
                }

                Console.WriteLine("-- Students: ");
                foreach (var person in context.People.OfType<Student>())
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName} ({person.EnrollmentDate})");
                }

            }
        }

        [TestMethod]
        public void EntitySplittingWithOfficeAssignment()
        {
            using (var context = new SchoolEntities())
            {
                foreach (var person in context.People.OfType<Professor>())
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName} ({person.Location})");
                }

            }
        }
    }
}
