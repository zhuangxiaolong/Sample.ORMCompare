using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sample.Repository.EF.Models
{
    public partial class MusicStoreContext : DbContext
    {
        public MusicStoreContext()
        {
        }

        public MusicStoreContext(DbContextOptions<MusicStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TMusic> TMusic { get; set; }
        public virtual DbSet<TUser> TUser { get; set; }
        public virtual DbSet<TUserMusic> TUserMusic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=MusicStore;user id=sa;password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TMusic>(entity =>
            {
                entity.ToTable("tMusic");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.ToTable("tUser");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Pw)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TUserMusic>(entity =>
            {
                entity.ToTable("tUserMusic");
            });
        }
    }
}
