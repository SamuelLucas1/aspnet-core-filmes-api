using FilmesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.DbContexts
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Diretor> Diretores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diretor>()
                .HasMany(d => d.Filmes)
                .WithOne(f => f.Diretor)
                .HasForeignKey(f => f.DiretorId)
                .IsRequired();
        }
    }
}