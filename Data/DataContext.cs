using Microsoft.EntityFrameworkCore;

namespace KeyValuePairAssignment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-71UULJJ\\SQLEXPRESS;Database=KeyValueDB;Trusted_Connection=true;TrustServerCertificate=true");

        }

        public DbSet<KeyValueModel> KeyValues { get; set; }


    }
}
