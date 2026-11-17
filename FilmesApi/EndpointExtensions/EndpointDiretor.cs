namespace FilmesApi.API.EndpointHandlers
{
    public static class EndpointDiretor
    {
        public static void MapDiretorEndpoints(this WebApplication app)
        {
            app.MapGet("/diretores", DiretorHandler.GetDiretoresAsync);

            app.MapGet("/diretores/agregacao/{name}", DiretorHandler.GetDiretorByNameAsync);

            app.MapGet("/diretores/where/{id}", DiretorHandler.GetDiretorByIdAsync);

            app.MapPost("/diretores", DiretorHandler.CreateDiretorAsync);

            app.MapPut("/diretores", DiretorHandler.UpdateDiretorAsync);

            app.MapDelete("/diretores/{diretorId}", DiretorHandler.DeleteDiretorAsync);
        }
    }
}