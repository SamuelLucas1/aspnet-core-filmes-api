using FilmesApi.API.Domain.Entities;
using FilmesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.API.Repo.Contexts
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Diretor> Diretores { get; set; }
        public DbSet<DiretorFilme> DiretoresFilmes { get; set; }
        public DbSet<DiretorDetalhe> DiretoresDetalhes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diretor>()
                .HasMany(d => d.Filmes)
                .WithMany(f => f.Diretores)
                .UsingEntity<DiretorFilme>(
                    df => df.HasOne<Filme>(e => e.Filme)
                            .WithMany(e => e.DiretoresFilmes)
                            .HasForeignKey(df => df.FilmeId),
                    df => df.HasOne<Diretor>(e => e.Diretor)
                            .WithMany(e => e.DiretoresFilmes)
                            .HasForeignKey(df => df.DiretorId),
                    df => {
                        df.HasKey(e => new { e.DiretorId, e.FilmeId });
                        df.ToTable("DiretoresFilmes");
                    }
                );

            modelBuilder.Entity<Diretor>()
                .HasOne(d => d.DiretorDetalhe)
                .WithOne(dd => dd.Diretor)
                .HasForeignKey<DiretorDetalhe>(dd => dd.DiretorId);

            modelBuilder.Entity<Diretor>().HasData(
                new Diretor { Id = 1, Name = "Steven Spielberg" },
                new Diretor { Id = 2, Name = "Christopher Nolan" },
                new Diretor { Id = 3, Name = "Quentin Tarantino" },
                new Diretor { Id = 4, Name = "Martin Scorsese" },
                new Diretor { Id = 5, Name = "James Cameron" }
            );

            modelBuilder.Entity<DiretorDetalhe>().HasData(
                new DiretorDetalhe { Id = 1, DiretorId = 1, Biografia = "Steven Spielberg é um renomado diretor de cinema americano, conhecido por seus filmes icônicos e inovadores.", DataNascimento = new DateTime(1946, 12, 18) },
                new DiretorDetalhe { Id = 2, DiretorId = 2, Biografia = "Christopher Nolan é um diretor britânico-americano, famoso por seus filmes complexos e visualmente impressionantes.", DataNascimento = new DateTime(1970, 7, 30) }
            );

            modelBuilder.Entity<Filme>().HasData(
                // Steven Spielberg
                new Filme { Id = 1, Title = "Jurassic Park", Year = 1993, },
                new Filme { Id = 2, Title = "Jaws", Year = 1975, },
                new Filme { Id = 3, Title = "E.T. the Extra-Terrestrial", Year = 1982, },
                new Filme { Id = 4, Title = "Schindler's List", Year = 1993, },

                // Christopher Nolan
                new Filme { Id = 5, Title = "Inception", Year = 2010, },
                new Filme { Id = 6, Title = "The Dark Knight", Year = 2008, },
                new Filme { Id = 7, Title = "Interstellar", Year = 2014, },

                // Quentin Tarantino
                new Filme { Id = 8, Title = "Pulp Fiction", Year = 1994, },
                new Filme { Id = 9, Title = "Kill Bill: Vol. 1", Year = 2003, },
                new Filme { Id = 10, Title = "Django Unchained", Year = 2012, },

                // Martin Scorsese
                new Filme { Id = 11, Title = "Goodfellas", Year = 1990, },
                new Filme { Id = 12, Title = "Taxi Driver", Year = 1976, },
                new Filme { Id = 13, Title = "The Departed", Year = 2006, },

                // James Cameron
                new Filme { Id = 14, Title = "Titanic", Year = 1997, },
                new Filme { Id = 15, Title = "Avatar", Year = 2009, },
                new Filme { Id = 16, Title = "Terminator 2: Judgment Day", Year = 1991, }
            );

            modelBuilder.Entity<DiretorFilme>().HasData(
                // Steven Spielberg
                new { DiretorId = 1, FilmeId = 1 },
                new { DiretorId = 1, FilmeId = 2 },
                new { DiretorId = 1, FilmeId = 3 },
                new { DiretorId = 1, FilmeId = 4 },
                // Christopher Nolan
                new { DiretorId = 2, FilmeId = 5 },
                new { DiretorId = 2, FilmeId = 6 },
                new { DiretorId = 2, FilmeId = 7 },
                // Quentin Tarantino
                new { DiretorId = 3, FilmeId = 8 },
                new { DiretorId = 3, FilmeId = 9 },
                new { DiretorId = 3, FilmeId = 10 },
                // Martin Scorsese
                new { DiretorId = 4, FilmeId = 11 },
                new { DiretorId = 4, FilmeId = 12 },
                new { DiretorId = 4, FilmeId = 13 },
                // James Cameron
                new { DiretorId = 5, FilmeId = 14 },
                new { DiretorId = 5, FilmeId = 15 },
                new { DiretorId = 5, FilmeId = 16 }
            );
        }
    }
}