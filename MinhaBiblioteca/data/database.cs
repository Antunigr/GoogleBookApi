using Microsoft.EntityFrameworkCore;
using MinhaBiblioteca.Models;

namespace WebApplication1.data
{
    public class database : DbContext
    {

        public database() { }

        public database(DbContextOptions<database> options) : base(options) { }

        public DbSet<RegisterModel> registrar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=tcp:azureserver.database.windows.net,1433;Initial Catalog=AzureSQLDb;Persist Security Info=False;User ID=antun1;Password=ServerEstud@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}