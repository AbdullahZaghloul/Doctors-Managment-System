using Microsoft.EntityFrameworkCore;

namespace MVC_Task1.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Doctors;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
