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
                //var data = db.Course.Where(p => p.Title.Contains("Git")).ToList();
                var data = (from p in db.Course
                            where p.Title.Contains("Git")
                            select p).ToList();

                foreach (var item in data)
                {
                    Console.WriteLine(item.Title);
                }
            }
        }
    }
}
