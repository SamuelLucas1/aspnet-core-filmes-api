using FilmesApi.API.Domain.Entities;

namespace FilmesApi.Repo.Contracts
{
    public interface IFilmeRepository
    {
        Task<IEnumerable<Filme>> GetFilmesAsync();
        Task<Filme?> GetFilmeByIdAsync(int id); // pode devolver null
        Task<IEnumerable<Filme>> GetFilmesEFFunctionsByTituloAsync(string titulo);
        Task<IEnumerable<Filme>> GetFilmesContainsByTituloAsync(string titulo);
        Task<bool> UpdateFilmeAsync(int id, string title, int year);         // false = não achou
        Task<int> ExecuteUpdateFilmeAsync(int id, string title, int year);   // linhas afetadas
        Task DeleteAsync(int filmeId);
        Task<bool> SaveChangesAsync();
    }
}