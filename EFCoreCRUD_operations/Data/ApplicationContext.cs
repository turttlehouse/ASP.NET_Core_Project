using EFCoreCRUD_operations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;



namespace EFCoreCRUD_operations.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options) :base(options){ }

        public DbSet<Employees> Employees { get; set; }  //we have defined the Table named to be Employees here which the one outside of the Dbset
    }
}
