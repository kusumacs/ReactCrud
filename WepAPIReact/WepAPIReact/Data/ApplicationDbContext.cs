using Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.Data
{
    public class ApplicationDbContext:DbContext
    {
        //General syntz-connectio to EF 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        //To create table
        public DbSet<EmployeeEY> EmployeesEY { get; set; }//Table name: Categories
    }
}
