using FilmesApi.Repo.Contracts;

namespace FilmesApi.API.EndpointHandlers;

public static class DiretorDetalheHandler
{
    public static IResult GetDiretorDetalheById(IDiretorDetalhe repository, int id)
    {
        var detalhe = repository.GetDiretorDetalheById(id);

        if (detalhe is null)
            return Results.NotFound("Detalhe do diretor não encontrado.");

        return Results.Ok(detalhe);
    }
}