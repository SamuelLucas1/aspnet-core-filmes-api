namespace FilmesApi.API.EndpointHandlers
{
    public static class EndpointFilme
    {
        public static void MapFilmeEndpoints(this WebApplication app)
        {
            app.MapGet("/filmes", FilmeHandler.GetFilmesAsync);

            app.MapGet("/filmes/{id}", FilmeHandler.GetFilmeByIdAsync);

            app.MapGet("/filmesEFFunctions/byName/{titulo}", FilmeHandler.GetFilmesEFFunctionsByTituloAsync);

            app.MapGet("/filmesContains/byName/{titulo}", FilmeHandler.GetFilmesContainsByTituloAsync);

            app.MapDelete("/filmes/{filmeId}", FilmeHandler.DeleteFilmeAsync);

            app.MapPatch("/filmesUpdate", FilmeHandler.UpdateFilmeAsync);

            app.MapPatch("/filmesExecuteUpdate", FilmeHandler.ExecuteUpdateFilmeAsync);
        }
    }
}