using CRUD_Web_API_net6.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Web_API_net6.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=(localdb)\\SQL-TRAINING; database=TrainingDB; Trusted_Connection=True;");
        }

        public DbSet<Heroes> Heroes => Set<Heroes>();
    }
}
