using FilmesApi.API.Repo.Contexts;
using FilmesApi.Domain.Entities;
using FilmesApi.Repo.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Repo;

public class DiretorDetalheRepository(Context _context) : IDiretorDetalhe
{
    public Context Context { get; set; } = _context;

    public async Task<DiretorDetalhe?> GetDiretorDetalheByIdAsync(int id)
    {
        return await Context.DiretoresDetalhes.FirstOrDefaultAsync(d => d.Id == id);
    }
}