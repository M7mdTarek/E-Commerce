using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Enitties
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = . ; Database = ITI-Project ; Trusted_Connection = True ; Encrypt = False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        

    }
}
