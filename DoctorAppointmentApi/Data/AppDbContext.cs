using DoctorAppointmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DoctorAppointment> DoctorAppointments { get; set; }
    }
}