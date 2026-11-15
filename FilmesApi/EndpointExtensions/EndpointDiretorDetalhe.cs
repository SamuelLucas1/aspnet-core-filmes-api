using FilmesApi.API.EndpointHandlers;

namespace FilmesApi.API.EndpointExtensions
{
    public static class EndpointDiretorDetalhe
    {
        public static void MapDiretorDetalheEndpoints(this WebApplication app)
        {
            app.MapGet("/diretorDetalhe/{id}", DiretorDetalheHandler.GetDiretorDetalheById);
        }
    }
}