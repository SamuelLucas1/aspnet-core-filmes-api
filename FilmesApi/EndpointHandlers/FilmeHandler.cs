using FilmesApi.API.Domain.Entities;
using FilmesApi.API.Models;
using FilmesApi.Repo.Contracts;

namespace FilmesApi.API.EndpointHandlers
{
    public static class FilmeHandler
    {
        public static async Task<IEnumerable<Filme>> GetFilmesAsync(IFilmeRepository IFilmerepository)
        {
            return await IFilmerepository.GetFilmesAsync();
        }

        public static async Task<Filme?> GetFilmeByIdAsync(IFilmeRepository IFilmerepository, int id)
        {
            return await IFilmerepository.GetFilmeByIdAsync(id);
        }

        public static async Task<IEnumerable<Filme>> GetFilmesEFFunctionsByTituloAsync(IFilmeRepository IFilmerepository, string titulo)
        {
            return await IFilmerepository.GetFilmesEFFunctionsByTituloAsync(titulo);
        }

        public static async Task<IEnumerable<Filme>> GetFilmesContainsByTituloAsync(IFilmeRepository IFilmerepository, string titulo)
        {
            return await IFilmerepository.GetFilmesContainsByTituloAsync(titulo);
        }

        public static async Task DeleteFilmeAsync(IFilmeRepository IFilmerepository, int filmeId)
        {
            await IFilmerepository.DeleteAsync(filmeId);
        }

        public static async Task<IResult> UpdateFilmeAsync(IFilmeRepository repo, FilmeUpdate dto)
        {
            if (!await repo.UpdateFilmeAsync(dto.Id, dto.Title, dto.Year))
                return Results.NotFound($"Filme nao encontrado! Tem certeza que digitou corretamente? -- ID:'{dto.Id}'");

            await repo.SaveChangesAsync();
            return Results.Ok($"Filme com o ID {dto.Id} atualizado com sucesso!");
        }

        public static async Task<IResult> ExecuteUpdateFilmeAsync(IFilmeRepository repo, FilmeUpdate dto)
        {
            var rows = await repo.ExecuteUpdateFilmeAsync(dto.Id, dto.Title, dto.Year);

            return rows == 0
                ? Results.NotFound($"Filme nao encontrado! Tem certeza que digitou corretamente? -- ID:'{dto.Id}'")
                : Results.Ok($"Filme com o ID {dto.Id} atualizado com sucesso!");
        }
    }
}