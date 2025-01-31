using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AspireTest.ApiService
{

    public partial class BancoContext(DbContextOptions<BancoContext> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ////if (!optionsBuilder.IsConfigured)
            ////{
            ////    IConfigurationRoot configuration = new ConfigurationBuilder()
            ////      .SetBasePath(Directory.GetCurrentDirectory())
            ////      .AddJsonFile("appsettings.json")
            ////      .Build();
            ////    var connectionString = configuration.GetConnectionString("database");
            ////    optionsBuilder.UseSqlServer(connectionString);
            ////}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}
