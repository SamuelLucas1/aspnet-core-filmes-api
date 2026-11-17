using FilmesApi.API.Domain.Entities;
using FilmesApi.Repo.Contracts;

namespace FilmesApi.API.EndpointHandlers
{
    public static class DiretorHandler
    {
        public static async Task<IEnumerable<Diretor>> GetDiretoresAsync(IDiretorRepository diretorRepository)
        {
            return await diretorRepository.GetDiretoresAsync();
        }

        public static async Task<Diretor> GetDiretorByNameAsync(IDiretorRepository diretorRepository, string name)
        {
            return await diretorRepository.GetDiretorByNameAsync(name);
        }

        public static async Task<IEnumerable<Diretor>> GetDiretorByIdAsync(IDiretorRepository diretorRepository, int id)
        {
            return await diretorRepository.GetDiretorByIdAsync(id);
        }

        public static async Task CreateDiretorAsync(IDiretorRepository diretorRepository, Diretor diretor)
        {
            await diretorRepository.AddAsync(diretor);
            await diretorRepository.SaveChangesAsync();
        }

        public static async Task UpdateDiretorAsync(IDiretorRepository diretorRepository, Diretor diretorNovo)
        {
            await diretorRepository.UpdateAsync(diretorNovo);
            await diretorRepository.SaveChangesAsync();
        }

        public static async Task DeleteDiretorAsync(IDiretorRepository diretorRepository, int diretorId)
        {
            await diretorRepository.DeleteAsync(diretorId);
            await diretorRepository.SaveChangesAsync();
        }
    }
}