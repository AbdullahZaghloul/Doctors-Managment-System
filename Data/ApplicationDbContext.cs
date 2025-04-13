using Microsoft.EntityFrameworkCore;
using MVC_Task1.Models;

namespace MVC_Task1.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments  { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Doctors;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
