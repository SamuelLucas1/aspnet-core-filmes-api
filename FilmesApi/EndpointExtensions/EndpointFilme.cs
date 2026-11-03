namespace FilmesApi.API.EndpointHandlers
{
    public static class EndpointFilme
    {
        public static void MapFilmeEndpoints(this WebApplication app)
        {
            app.MapGet("/filmes", FilmeHandler.GetFilmes);

            app.MapGet("/filmes/{id}", FilmeHandler.GetFilmeById);

            app.MapGet("/filmesEFFunctions/byName/{titulo}", FilmeHandler.GetFilmesEFFunctionsByTitulo);

            app.MapGet("/filmesContains/byName/{titulo}", FilmeHandler.GetFilmesContainsByTitulo);

            app.MapDelete("/filmes/{filmeId}", FilmeHandler.DeleteFilme);

            app.MapPatch("/filmesUpdate", FilmeHandler.UpdateFilme);

            app.MapPatch("/filmesExecuteUpdate", FilmeHandler.ExecuteUpdateFilme);
        }
    }
}