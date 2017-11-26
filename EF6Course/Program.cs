using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Course
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ContosoUniversityEntities())
            {
                db.Database.Log = (sql) => { Console.WriteLine(sql); };

                //GetCourse_Git(db);
                //GetDepartment(db);
                //AddCourse(db);
                //UpdateCourse(db);
                //DeleteCourse(db);

                
            }
        }

        private static void DeleteCourse(ContosoUniversityEntities db)
        {
            //var c = db.Course.Find(9);

            //var c = db.Course.FirstOrDefault(p => p.Title.StartsWith("Git"));
            //db.Course.Remove(c);

            var c = db.Course.Where(p => p.Title.StartsWith("Git"));
            db.Course.RemoveRange(c);

            db.SaveChanges();
        }

        private static void UpdateCourse(ContosoUniversityEntities db)
        {
            var items = db.Course.Where(p => p.Title.Contains("Git"));
            foreach (var item in items)
            {
                item.Credits += 1;
                item.CreatedOn = DateTime.Now;
                item.UpdatedOn = DateTime.Now;
            }
            db.SaveChanges();
        }

        private static void AddCourse(ContosoUniversityEntities db)
        {
            var c = new Course()
            {
                Title = "Entity Framework 6.1",
                Credits = 100,
                IsDeleted = false
            };
            c.Department = db.Department.Find(2);
            db.Course.Add(c);
            db.SaveChanges();
        }

        private static void GetDepartment(ContosoUniversityEntities db)
        {
            var data = (from p in db.Department.Include("Course") select p);
            foreach (var dept in data)
            {
                Console.WriteLine(dept.Name);
                foreach (var course in dept.Course)
                {
                    Console.WriteLine("\t" + course.Title);
                }
            }
        }

        private static void GetCourse_Git(ContosoUniversityEntities db)
        {
            //var data = db.Course.Where(p => p.Title.Contains("Git")).ToList();
            var data = (from p in db.Course
                        where p.Title.Contains("Git")
                        select p).ToList();

            foreach (var item in data)
            {
                Console.WriteLine(item.Title + "\t" + item.Department.Name);
            }
        }
    }
}
