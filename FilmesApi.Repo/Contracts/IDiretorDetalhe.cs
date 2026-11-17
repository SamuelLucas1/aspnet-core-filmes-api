using FilmesApi.Domain.Entities;

namespace FilmesApi.Repo.Contracts
{
    public interface IDiretorDetalhe
    {
        Task<DiretorDetalhe?> GetDiretorDetalheByIdAsync(int id); // pode devolver null
    }
}