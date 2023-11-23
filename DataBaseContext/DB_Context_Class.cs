using Microsoft.EntityFrameworkCore;
using DatabaseEntityLib;
using System.Reflection.Emit;

namespace DataBaseContext
{
    public class DB_Context_Class : DbContext
    {
        public DbSet<Ispit> Ispit { get; set; }
        public DbSet<IspitniRok> IspitniRok { get; set; }
        public DbSet<Prijava> Prijava { get; set; }
        public DbSet<Student> Student { get; set; }

        public DB_Context_Class(DbContextOptions<DB_Context_Class> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ispit>()
                .Property(i => i.Name)
                .IsRequired();




/*            modelBuilder.Entity<IspitniRok>()
                .Property(i => i.Regular)
                .IsRequired();*/




            modelBuilder.Entity<Prijava>()
                .Property(p => p.IspitID)
                .IsRequired();
            modelBuilder.Entity<Prijava>()
                .Property(p => p.StudentID)
                .IsRequired();
            modelBuilder.Entity<Prijava>()
                .Property(p => p.IspitniRokID)
                .IsRequired();




            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .IsRequired();
            modelBuilder.Entity<Student>()
                .Property(s => s.Surname)
                .IsRequired();



            modelBuilder.Entity<Student>()
                .HasMany(s => s.IspitnePrijave).WithOne(p => p.Student).HasForeignKey(p => p.StudentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ispit>()
                .HasMany(i => i.Prijave).WithOne(p => p.Ispit).HasForeignKey(p => p.IspitID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<IspitniRok>()
                .HasMany(i => i.IspitnePrijave).WithOne(p => p.IspitniRok).HasForeignKey(p => p.IspitniRokID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}