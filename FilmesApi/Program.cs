using FilmesApi.DbContexts;
using FilmesApi.Entities;
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
                options.UseSqlite(
                    builder.Configuration.GetConnectionString("FilmeApiStr"));
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