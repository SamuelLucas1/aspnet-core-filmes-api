using FilmesApi.DbContexts;
using FilmesApi.Entities;
using FilmesApi.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace FilmesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("FilmeApiStr"))
                       .LogTo(Console.WriteLine, LogLevel.Information);
            });

            //using(var context = new Context())
            //{
            //    context.Database.EnsureCreated();
            //}
            
            // Serviços
            builder.Services.AddAuthorization();

            // OpenAPI
            builder.Services.AddOpenApi();

            // Swagger UI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.AllowTrailingCommas = true;
                options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider
                    .GetRequiredService<Context>();

                context.Database.EnsureCreated();
            }

            // Configuração do ambiente
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/diretores", (Context context) =>
            {
                return context.Diretores.Include(diretor => diretor.Filmes)
                .ToList();
            });

            app.MapGet("/diretores/agregacao/{name}", (Context context, string name) =>
            {
                //return context.Diretores
                //    .Include(diretor => diretor.Filmes)
                //    .Select(diretor => diretor.Name)
                //    .FirstOrDefault(diretor => diretor.Name.Contains(name))
                //    ?? new Diretor { Id = 0, Name = "Nao existe esse nome" };

                return context.Diretores
                    .Include(diretor => diretor.Filmes)
                    .Select(diretor => diretor.Name)
                    .FirstOrDefault()
                    ?? "Nao existe esse nome";
            });

            app.MapGet("/diretores/where/{id}", (Context context, int id) =>
            {
                return context.Diretores
                    .Where(diretor => diretor.Id == id)
                    .Include(diretor => diretor.Filmes)
                    .ToList();
            });

            app.MapGet("/filmes", (Context context) =>
            {
                return context.Filmes
                    .Include(filme => filme.Diretor)
                    .OrderByDescending(filme => filme.Year)
                    .ThenBy(filme => filme.Title)
                    .ToList();
            });

            app.MapGet("/filmes/{id}", (Context context, int id) =>
            {   
                return context.Filmes
                    .Where(filme => filme.Id == id)
                    .Include(filme => filme.Diretor)
                    .ToList();
            });

            app.MapGet("/filmesEFFunctions/byName/{titulo}", (Context context, string titulo) =>
            {
                return context.Filmes
                    .Where(filme => EF.Functions.Like(filme.Title, $"%{titulo}%"))
                    .Include(filme => filme.Diretor)
                    .ToList();
            });

            app.MapGet("/filmesLinQ/byName/{titulo}", (Context context, string titulo) =>
            {
                return context.Filmes
                    .Where(filme => filme.Title.Contains(titulo))
                    .Include(filme => filme.Diretor)
                    .ToList();
            });

            app.MapPost("/diretores", (Context context, Diretor diretor) =>
            {
                context.Diretores.Add(diretor);
                context.SaveChanges();
            });

            app.MapPut("/diretores/{diretorId}", (Context context, int diretorId, Diretor diretorNovo) =>
            {
                var diretor = context.Diretores.Find(diretorId);

                if(diretor != null)
                {
                    diretor.Name = diretorNovo.Name;
                    if(diretorNovo.Filmes.Count > 0)
                    {
                        diretor.Filmes.Clear();
                        foreach(var filme in diretorNovo.Filmes)
                        {
                            diretor.Filmes.Add(filme);
                        }
                    }
                }

                context.SaveChanges();
            });

            app.MapDelete("/filmes/{filmeId}", (Context context, int filmeId) =>
            {
                context.Filmes
                    .Where(filme => filme.Id == filmeId)
                    .ExecuteDelete<Filme>();
            });

            app.MapPatch("/filmesUpdate", (Context context, FilmeUpdate filmeUpdate) =>
            {
                var filme = context.Filmes.Find(filmeUpdate.Id);

                if(filme == null)
                {
                    return Results.NotFound($"Filme nao encontrado! Tem certeza que digitou corretamente? -- ID:'{filmeUpdate.Id}'");
                }

                filme.Title = filmeUpdate.Title;
                filme.Year = filmeUpdate.Year;

                context.Filmes.Update(filme);
                context.SaveChanges();

                return Results.Ok($"Filme com o ID {filmeUpdate.Id} atualizado com sucesso!");
            });

            app.MapPatch("/filmesExecuteUpdate", (Context context, FilmeUpdate filmeUpdate) =>
            {
                var affectedRows = context.Filmes
                    .Where(filme => filme.Id == filmeUpdate.Id)
                    .ExecuteUpdate(setter => setter
                        .SetProperty(f => f.Title, filmeUpdate.Title)
                        .SetProperty(f => f.Year, filmeUpdate.Year)
                    );

                if(affectedRows > 0)
                {
                    return Results.Ok($"Voce teve um total de {affectedRows}");
                }
                else
                {
                    return Results.NotFound($"Nenhuma linha foi afetada.");
                }
            });

            app.MapDelete("/diretores/{diretorId}", (Context context, int diretorId) =>
            {
                var diretor = context.Diretores.Find(diretorId);

                if(diretor != null)
                    context.Diretores.Remove(diretor);

                context.SaveChanges();
            });

            app.Run();
        }
    }
}