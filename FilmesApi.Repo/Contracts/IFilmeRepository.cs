using FilmesApi.API.Domain.Entities;

namespace FilmesApi.Repo.Contracts
{
    public interface IFilmeRepository
    {
        IEnumerable<Filme> GetFilmes();
        Filme? GetFilmeById(int id); // pode devolver null
        IEnumerable<Filme> GetFilmesEFFunctionsByTitulo(string titulo);
        IEnumerable<Filme> GetFilmesContainsByTitulo(string titulo);
        bool UpdateFilme(int id, string title, int year);         // false = não achou
        int ExecuteUpdateFilme(int id, string title, int year);   // linhas afetadas
        void Delete(int filmeId);
        bool SaveChanges();
    }
}