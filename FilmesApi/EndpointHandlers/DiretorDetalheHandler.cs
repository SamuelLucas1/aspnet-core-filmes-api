using FilmesApi.Repo.Contracts;

namespace FilmesApi.API.EndpointHandlers;

public static class DiretorDetalheHandler
{
    public static async Task<IResult> GetDiretorDetalheByIdAsync(IDiretorDetalhe repository, int id)
    {
        var detalhe = await repository.GetDiretorDetalheByIdAsync(id);

        if (detalhe is null)
            return Results.NotFound("Detalhe do diretor não encontrado.");

        return Results.Ok(detalhe);
    }
}