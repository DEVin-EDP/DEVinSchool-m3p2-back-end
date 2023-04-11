using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Seeds;

namespace Infrastructure.Repository
{
    internal class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<CourseModel> Curso { get; set; }
        public DbSet<UserModel> Usuario { get; set; }
        public DbSet<CursoSalvoModel> CursoSalvo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseModel>()
                .Property(x => x.CategoriaCurso)
                .HasConversion<string>()
                .HasMaxLength(100);

            modelBuilder.Entity<CursoSalvoModel>()
                .Property(x => x.StatusCurso)
                .HasConversion<string>()
                .HasMaxLength(100);

            modelBuilder.Entity<CursoSalvoModel>()
                .Property(x => x.DataCursoSalvo)
                .HasConversion(
                    v => v.ToString("yyyy-MM-dd"),
                    v => DateOnly.Parse(v))
                .HasMaxLength(100);

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<CourseModel>().HasData(CursoSeed.Seed);
            modelBuilder.Entity<UserModel>().HasData(UsuarioSeed.Seed);
        }
    }
}
