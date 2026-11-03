namespace FilmesApi.API.EndpointHandlers
{
    public static class EndpointDiretor
    {
        public static void MapDiretorEndpoints(this WebApplication app)
        {
            app.MapGet("/diretores", DiretorHandler.GetDiretores);

            app.MapGet("/diretores/agregacao/{name}", DiretorHandler.GetDiretorByName);

            app.MapGet("/diretores/where/{id}", DiretorHandler.GetDiretorById);

            app.MapPost("/diretores", DiretorHandler.CreateDiretor);

            app.MapPut("/diretores", DiretorHandler.UpdateDiretor);

            app.MapDelete("/diretores/{diretorId}", DiretorHandler.DeleteDiretor);
        }
    }
}