using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TestCreateAPI.Models.Models;

namespace TestCreateAPI.Models.Context
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }
        
        public DbSet<Mahasiswa> Mahasiswa { get; set; }
        public DbSet<MataKuliah> MataKuliah { get; set; }
        public DbSet<Kuliah> Kuliah { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            base.OnModelCreating(builder);
        }

    }
}
