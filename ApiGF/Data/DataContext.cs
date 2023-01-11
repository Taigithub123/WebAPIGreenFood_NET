using ApiGF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ApiGF.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DbContext> options) : base(options)
        {

        }
        public DataContext(){}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DefaultString");
                options.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Categories)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.IdCategory);
            modelBuilder.Entity<Category>().HasData(new
            {
                IdCategory=1,
                Name ="Cá"
            },
            new
            {
                IdCategory = 2,
                Name ="Rau"
            });

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
