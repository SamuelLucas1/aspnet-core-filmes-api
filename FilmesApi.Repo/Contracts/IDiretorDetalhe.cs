using FilmesApi.Domain.Entities;

namespace FilmesApi.Repo.Contracts
{
    public interface IDiretorDetalhe
    {
        DiretorDetalhe? GetDiretorDetalheById(int id); // pode devolver null
    }
}