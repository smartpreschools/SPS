using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SPS.Data.Models
{
    public partial class SPSContext : DbContext
    {
        public SPSContext()
        {
        }

        public SPSContext(DbContextOptions<SPSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryDetail> CategoryDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=45.64.104.120,52894;Initial Catalog=DBSPS; uid=smartpreschool;Password=sara!@#123; Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("smartpreschool");

            modelBuilder.Entity<CategoryDetail>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryDesc).HasMaxLength(500);

                entity.Property(e => e.CategoryName).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
