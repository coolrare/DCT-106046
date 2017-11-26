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
                //db.Database.Log = (sql) => { Console.WriteLine(sql); };

                //GetCourse_Git(db);
                //GetDepartment(db);

            }
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
