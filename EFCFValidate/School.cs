using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCFValidate
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }

    public class Classes
    {
        [Key]
        public int ClassNumber { get; set; }
        public string className { get; set; }
        public int creditHours { get; set; }
    }
    public class MyContext : DbContext
    {
        public MyContext() : base()
        {
            Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Classes> Class { get; set; }
    }
}
