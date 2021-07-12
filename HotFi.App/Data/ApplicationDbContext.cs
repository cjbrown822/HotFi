using System;
using HotFi.App.Extensions;
using HotFi.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotFi.App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<ApplicationUser> Users { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<DigitalOceanDroplet> Droplets { get; set; }
        public virtual DbSet<ServerInformation> ServerInformation { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DigitalOceanDroplet>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ServerInformation>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id)
                    .ValueGeneratedOnAdd();
            });

            this.MapForPostgreSql("hotfi", modelBuilder);
        }
    }
}