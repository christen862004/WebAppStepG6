using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace WebAppStepG6.Models
{
    //
    public class StepsContext:DbContext
    {
        //class =>table
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        /** DBContextOption
         1) DBMS
         2) server name
         3) Login Auth
         4) Databse name
         */
        public StepsContext():base()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=StepsG6;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
