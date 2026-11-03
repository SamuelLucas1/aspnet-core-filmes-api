using FilmesApi.API.Domain.Entities;
using FilmesApi.API.Models;
using FilmesApi.API.Repo.Contexts;
using FilmesApi.Repo.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.API.EndpointHandlers
{
    public static class FilmeHandler
    {
        public static IEnumerable<Filme> GetFilmes(IFilmeRepository IFilmerepository)
        {
            return IFilmerepository.GetFilmes();
        }

        public static Filme GetFilmeById(IFilmeRepository IFilmerepository, int id)
        {
            return IFilmerepository.GetFilmeById(id);
        }

        public static IEnumerable<Filme> GetFilmesEFFunctionsByTitulo(IFilmeRepository IFilmerepository, string titulo)
        {
            return IFilmerepository.GetFilmesEFFunctionsByTitulo(titulo);
        }

        public static IEnumerable<Filme> GetFilmesContainsByTitulo(IFilmeRepository IFilmerepository, string titulo)
        {
            return IFilmerepository.GetFilmesContainsByTitulo(titulo);
        }

        public static void DeleteFilme(IFilmeRepository IFilmerepository, int filmeId)
        {
            IFilmerepository.Delete(filmeId);
        }

        public static IResult UpdateFilme(IFilmeRepository repo, FilmeUpdate dto)
        {
            if (!repo.UpdateFilme(dto.Id, dto.Title, dto.Year))
                return Results.NotFound($"Filme nao encontrado! Tem certeza que digitou corretamente? -- ID:'{dto.Id}'");

            repo.SaveChanges();
            return Results.Ok($"Filme com o ID {dto.Id} atualizado com sucesso!");
        }

        public static IResult ExecuteUpdateFilme(IFilmeRepository repo, FilmeUpdate dto)
        {
            var rows = repo.ExecuteUpdateFilme(dto.Id, dto.Title, dto.Year);

            return rows == 0
                ? Results.NotFound($"Filme nao encontrado! Tem certeza que digitou corretamente? -- ID:'{dto.Id}'")
                : Results.Ok($"Filme com o ID {dto.Id} atualizado com sucesso!");
        }
    }
}