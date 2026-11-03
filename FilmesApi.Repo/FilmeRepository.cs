using FilmesApi.API.Domain.Entities;
using FilmesApi.API.Repo.Contexts;
using FilmesApi.Repo.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Repo
{
    public class FilmeRepository(Context _context) : IFilmeRepository
    {
        public Context Context { get; set; } = _context;

        public Filme? GetFilmeById(int id)
        {
            return Context.Filmes
                .Include(filme => filme.Diretor)
                .FirstOrDefault(filme => filme.Id == id)
                ?? new Filme { Id = 0, Title = "Nao existe esse filme" };
        }

        public IEnumerable<Filme> GetFilmes()
        {
            return Context.Filmes
                .Include(filme => filme.Diretor)
                .OrderByDescending(filme => filme.Year)
                .ThenBy(filme => filme.Title)
                .ToList();
        }

        public IEnumerable<Filme> GetFilmesContainsByTitulo(string titulo)
        {
            return Context.Filmes
                .Where(filme => filme.Title.Contains(titulo))
                .Include(filme => filme.Diretor)
                .ToList();
        }

        public IEnumerable<Filme> GetFilmesEFFunctionsByTitulo(string titulo)
        {
            return Context.Filmes
                .Where(filme => EF.Functions.Like(filme.Title, $"%{titulo}%"))
                .Include(filme => filme.Diretor)
                .ToList();
        }

        public bool UpdateFilme(int id, string title, int year)
        {
            var filme = Context.Filmes.Find(id);
            if (filme is null) return false;

            filme.Title = title;
            filme.Year = year;
            return true;               // o SaveChanges fica no handler
        }
        public int ExecuteUpdateFilme(int id, string title, int year)
        {
            return Context.Filmes
                .Where(f => f.Id == id)
                .ExecuteUpdate(s => s
                .SetProperty(f => f.Title, title)
                .SetProperty(f => f.Year, year));
        }

        public void Delete(int filmeId)
        {
            Context.Filmes
                .Where(filme => filme.Id == filmeId)
                .ExecuteDelete<Filme>();
        }

        public bool SaveChanges()
        {
            return Context.SaveChanges() > 0;
        }
    }
}   