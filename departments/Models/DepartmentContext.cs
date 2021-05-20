using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace departments.Models
{
    public partial class DepartmentContext : DbContext
    {
        //public DepartmentContext()
        //{
        //}

        //public DepartmentContext(DbContextOptions<DepartmentContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Phongban> Phongbans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new DbConnect().GetJson("appsettings.json");

            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DataContextConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Phongban>(entity =>
            {
                entity.ToTable("Phongban");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
