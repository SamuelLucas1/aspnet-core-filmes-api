using FilmesApi.API.Domain.Entities;
using FilmesApi.API.Repo.Contexts;
using FilmesApi.Repo.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.API.EndpointHandlers
{
    public static class DiretorHandler
    {
        public static IEnumerable<Diretor> GetDiretores(IDiretorRepository diretorRepository)
        {
            return diretorRepository.GetDiretores();
        }

        public static Diretor GetDiretorByName(IDiretorRepository diretorRepository, string name)
        {
            return diretorRepository.GetDiretorByName(name);
        }

        public static IEnumerable<Diretor> GetDiretorById(IDiretorRepository diretorRepository, int id)
        {
            return diretorRepository.GetDiretorById(id);
        }

        public static void CreateDiretor(IDiretorRepository diretorRepository, Diretor diretor)
        {
            diretorRepository.Add(diretor);
            diretorRepository.SaveChanges();
        }

        public static void UpdateDiretor(IDiretorRepository diretorRepository, Diretor diretorNovo)
        {
            diretorRepository.Update(diretorNovo);
            diretorRepository.SaveChanges();
        }

        public static void DeleteDiretor(IDiretorRepository diretorRepository, int diretorId)
        {
            diretorRepository.Delete(diretorId);
            diretorRepository.SaveChanges();
        }
    }
}