using FilmesApi.API.Domain.Entities;
using FilmesApi.API.Repo.Contexts;

namespace FilmesApi.Repo.Contracts
{
    public interface IDiretorRepository
    {
        IEnumerable<Diretor> GetDiretores();
        Diretor GetDiretorByName(string name);
        IEnumerable<Diretor> GetDiretorById(int id);
        void Add(Diretor diretor);
        void Update(Diretor diretor);
        void Delete(int diretorId);
        bool SaveChanges();
    }
}   