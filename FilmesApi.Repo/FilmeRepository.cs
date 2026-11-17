using FilmesApi.API.Domain.Entities;
using FilmesApi.API.Repo.Contexts;
using FilmesApi.Repo.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Repo
{
    public class FilmeRepository(Context _context) : IFilmeRepository
    {
        public Context Context { get; set; } = _context;

        public async Task<Filme?> GetFilmeByIdAsync(int id)
        {
            return await Context.Filmes
                .Include(filme => filme.Diretores)
                .FirstOrDefaultAsync(filme => filme.Id == id)
                ?? new Filme { Id = 0, Title = "Nao existe esse filme" };
        }

        public async Task<IEnumerable<Filme>> GetFilmesAsync()
        {
            return await Context.Filmes
                .Include(filme => filme.Diretores)
                .OrderByDescending(filme => filme.Year)
                .ThenBy(filme => filme.Title)
                .ToListAsync();
        }

        public async Task<IEnumerable<Filme>> GetFilmesContainsByTituloAsync(string titulo)
        {
            return await Context.Filmes
                .Include(filme => filme.Diretores)
                .Where(filme => filme.Title.Contains(titulo))
                .ToListAsync();
        }

        public async Task<IEnumerable<Filme>> GetFilmesEFFunctionsByTituloAsync(string titulo)
        {
            return await Context.Filmes
                .Include(filme => filme.Diretores)
                .Where(filme => EF.Functions.Like(filme.Title, $"%{titulo}%"))
                .ToListAsync();
        }

        public async Task<bool> UpdateFilmeAsync(int id, string title, int year)
        {
            var filme = await Context.Filmes.FindAsync(id);
            if (filme is null) return false;

            filme.Title = title;
            filme.Year = year;
            return true;               // o SaveChanges fica no handler
        }
        public async Task<int> ExecuteUpdateFilmeAsync(int id, string title, int year)
        {
            return await Context.Filmes
                .Where(f => f.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(f => f.Title, title)
                .SetProperty(f => f.Year, year));
        }

        public async Task DeleteAsync(int filmeId)
        {
            await Context.Filmes
                .Where(filme => filme.Id == filmeId)
                .ExecuteDeleteAsync<Filme>();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await Context.SaveChangesAsync()) > 0;
        }
    }
}   