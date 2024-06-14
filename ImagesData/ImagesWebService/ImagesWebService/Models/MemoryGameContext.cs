using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

//TO GET THIS FILE:
// I DID: Scaffold-DbContext ”Server=localHost;Database=MemoryGame;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
// IN THE PACKAGE MANAGER CONSOLE
// AFTER GETTING THE 5 INSTALLED PLUGINS FROM NUGET. (6.0.31)
namespace ImagesWebService.Models
{
    public partial class MemoryGameContext : DbContext
    {
        public MemoryGameContext()
        {
        }

        public MemoryGameContext(DbContextOptions<MemoryGameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<PlaySessionNames> PlaySessionNames { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localHost;Database=MemoryGame;User Id=MemoryGame;Password=images123;TrustServerCertificate=True");
                // HAVING Trusted_Connection = true; could pottentialy fix issues, for some it makes it worse, for some it makes it work...
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Image1).HasColumnName("Image");

                entity.Property(e => e.Name).HasMaxLength(60);
            });

            modelBuilder.Entity<PlaySessionNames>(entity =>
            entity.HasKey(e => e.Id));

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
