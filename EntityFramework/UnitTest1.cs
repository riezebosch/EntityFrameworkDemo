using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.Entity;

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
                    Console.WriteLine($"{person.FullName.FirstName} {person.FullName.LastName} ({person.HireDate})");
                }

                Console.WriteLine("-- Students: ");
                foreach (var person in context.People.OfType<Student>())
                {
                    Console.WriteLine($"{person.FullName.FirstName} {person.FullName.LastName} ({person.EnrollmentDate})");
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
                    Console.WriteLine($"{person.FullName.FirstName} {person.FullName.LastName} ({person.Location})");
                }

            }
        }

        [TestMethod]
        public void StudentGradesOnStudent()
        {
            using (var context = new SchoolEntities())
            {
                foreach (var student in context.People.OfType<Student>())
                {
                    Console.WriteLine($"{student.FullName.FirstName} {student.FullName.LastName}");
                    foreach (var grade in student.Grades)
                    {
                        Console.WriteLine($"  {grade.Course.Title}: {grade.Grade}");
                    }
                }

            }
        }

        [TestMethod]
        public void DemoVanQuery()
        {
            using (var context =new SchoolEntities())
            {
                var query = from p in context.People
                            where p.FullName.FirstName.StartsWith("Bob")
                            select p.FullName.LastName;

                Console.WriteLine(query);
            }
        }

        [TestMethod]
        public void WatIsLazyLoading()
        {
            using (var context = new SchoolEntities())
            {
                //context
                //    .Configuration
                //    .LazyLoadingEnabled = false;

                foreach (var persoon in context
                    .People
                    .OfType<Student>()
                    .Include(s => s.Grades))
                {
                    foreach (var grades in persoon.Grades)
                    {
                        Console.WriteLine(grades.Grade);
                    }
                }
            }
        }

        [TestMethod]
        public void FindVsSingleOrDefault()
        {
            using (var context = new SchoolEntities())
            {
                context.Database.Log = Console.WriteLine;

                int id = 6;
                var li1 = (from p in context.People
                          where p.PersonID == id
                          select p).SingleOrDefault();

                var li2 = context.People.Find(7);
            }
        }

        [TestMethod]
        public void PagingInEntityFramework()
        {
            using (var context = new SchoolEntities())
            {
                for (int i = 0; i < context.People.Count(); i += 5)
                {
                    Console.WriteLine($"[[[[{i}]]]]");
                    foreach (var p in context.People
                        .OrderBy(p => p.PersonID)
                        .Skip(() => i) // <---- query met constant zorgt voor constante query!
                        .Take(5))
                    {
                        Console.WriteLine($"{p.FullName.FirstName} {p.FullName.LastName}");
                    }
                }
            }
        }
    }
}
