using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContainerizedDataAccess.Entities
{
    public partial class mvcappdbContext : DbContext
    {
        public mvcappdbContext()
        {
        }

        public mvcappdbContext(DbContextOptions<mvcappdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Account__737584F62FD16171")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Item__AccountId__4CA06362");
            });
        }
    }
}
