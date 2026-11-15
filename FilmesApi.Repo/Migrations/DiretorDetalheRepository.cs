using FilmesApi.API.Repo.Contexts;
using FilmesApi.Domain.Entities;
using FilmesApi.Repo.Contracts;

namespace FilmesApi.Repo;

public class DiretorDetalheRepository(Context _context) : IDiretorDetalhe
{
    public Context Context { get; set; } = _context;

    public DiretorDetalhe? GetDiretorDetalheById(int id)
    {
        return Context.DiretoresDetalhes.FirstOrDefault(d => d.Id == id);
    }
}