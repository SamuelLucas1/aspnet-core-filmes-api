using FilmesApi.API.Domain.Entities;
using FilmesApi.API.Repo.Contexts;

namespace FilmesApi.Repo.Contracts
{
    public interface IDiretorRepository
    {
        Task<IEnumerable<Diretor>> GetDiretoresAsync();
        Task<Diretor> GetDiretorByNameAsync(string name);
        Task<IEnumerable<Diretor>> GetDiretorByIdAsync(int id);
        Task AddAsync(Diretor diretor);
        Task UpdateAsync(Diretor diretor);
        Task DeleteAsync(int diretorId);
        Task<bool> SaveChangesAsync();
    }
}   