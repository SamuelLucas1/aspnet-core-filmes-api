using FilmesApi.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.API.Repo.Contexts
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

            modelBuilder.Entity<Diretor>().HasData(
                new Diretor { Id = 1, Name = "Steven Spielberg" },
                new Diretor { Id = 2, Name = "Christopher Nolan" },
                new Diretor { Id = 3, Name = "Quentin Tarantino" },
                new Diretor { Id = 4, Name = "Martin Scorsese" },
                new Diretor { Id = 5, Name = "James Cameron" }
            );

            modelBuilder.Entity<Filme>().HasData(
                // Steven Spielberg
                new Filme { Id = 1, Title = "Jurassic Park", Year = 1993, DiretorId = 1 },
                new Filme { Id = 2, Title = "Jaws", Year = 1975, DiretorId = 1 },
                new Filme { Id = 3, Title = "E.T. the Extra-Terrestrial", Year = 1982, DiretorId = 1 },
                new Filme { Id = 4, Title = "Schindler's List", Year = 1993, DiretorId = 1 },

                // Christopher Nolan
                new Filme { Id = 5, Title = "Inception", Year = 2010, DiretorId = 2 },
                new Filme { Id = 6, Title = "The Dark Knight", Year = 2008, DiretorId = 2 },
                new Filme { Id = 7, Title = "Interstellar", Year = 2014, DiretorId = 2 },

                // Quentin Tarantino
                new Filme { Id = 8, Title = "Pulp Fiction", Year = 1994, DiretorId = 3 },
                new Filme { Id = 9, Title = "Kill Bill: Vol. 1", Year = 2003, DiretorId = 3 },
                new Filme { Id = 10, Title = "Django Unchained", Year = 2012, DiretorId = 3 },

                // Martin Scorsese
                new Filme { Id = 11, Title = "Goodfellas", Year = 1990, DiretorId = 4 },
                new Filme { Id = 12, Title = "Taxi Driver", Year = 1976, DiretorId = 4 },
                new Filme { Id = 13, Title = "The Departed", Year = 2006, DiretorId = 4 },

                // James Cameron
                new Filme { Id = 14, Title = "Titanic", Year = 1997, DiretorId = 5 },
                new Filme { Id = 15, Title = "Avatar", Year = 2009, DiretorId = 5 },
                new Filme { Id = 16, Title = "Terminator 2: Judgment Day", Year = 1991, DiretorId = 5 }
            );
        }
    }
}