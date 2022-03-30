using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DBModels.Init
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<brand> brands { get; set; }
        public virtual DbSet<laptop> laptops { get; set; }
        public virtual DbSet<loan> loans { get; set; }
        public virtual DbSet<spec> specs { get; set; }
        public virtual DbSet<student> students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .HasMany(e => e.loans)
                .WithOptional(e => e.admin)
                .HasForeignKey(e => e.admin_name);

            modelBuilder.Entity<brand>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<brand>()
                .HasMany(e => e.laptops)
                .WithOptional(e => e.brand)
                .HasForeignKey(e => e.brand_id);

            modelBuilder.Entity<laptop>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<laptop>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<laptop>()
                .Property(e => e.img)
                .IsUnicode(false);

            modelBuilder.Entity<laptop>()
                .HasMany(e => e.loans)
                .WithOptional(e => e.laptop)
                .HasForeignKey(e => e.laptop_id);

            modelBuilder.Entity<laptop>()
                .HasOptional(e => e.spec)
                .WithRequired(e => e.laptop);

            modelBuilder.Entity<loan>()
                .Property(e => e.student_id)
                .IsUnicode(false);

            modelBuilder.Entity<loan>()
                .Property(e => e.laptop_id)
                .IsUnicode(false);

            modelBuilder.Entity<loan>()
                .Property(e => e.admin_name)
                .IsUnicode(false);

            modelBuilder.Entity<spec>()
                .Property(e => e.laptop_id)
                .IsUnicode(false);

            modelBuilder.Entity<spec>()
                .Property(e => e.memory)
                .IsUnicode(false);

            modelBuilder.Entity<spec>()
                .Property(e => e.hard_drive)
                .IsUnicode(false);

            modelBuilder.Entity<spec>()
                .Property(e => e.graphic_card)
                .IsUnicode(false);

            modelBuilder.Entity<spec>()
                .Property(e => e.screen_solution)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .HasMany(e => e.loans)
                .WithOptional(e => e.student)
                .HasForeignKey(e => e.student_id);
        }
    }
}
