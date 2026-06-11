using AriTechno.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AriTechno.Database
{
    public class AriTechnoDB : DbContext
    {

        public AriTechnoDB(DbContextOptions<AriTechnoDB> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }



    }
}
