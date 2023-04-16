using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Seeds;

namespace Infrastructure.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<CursoSalvo> CursoSalvo { get; set; }
        public DbSet<CategoriaCurso> CategoriaCurso { get; set; }
        public DbSet<Perfil> Perfil { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CursoSalvo>()
                .Property(x => x.StatusCurso)
                .HasConversion<string>()
                .HasMaxLength(100);

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<Perfil>().HasData(PerfilSeed.Seed);
            modelBuilder.Entity<Curso>().HasData(CursoSeed.Seed);
            modelBuilder.Entity<Usuario>().HasData(UsuarioSeed.Seed);
            modelBuilder.Entity<CategoriaCurso>().HasData(CategoriaCursoSeed.Seed);
        }
    }
}
