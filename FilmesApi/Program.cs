using FilmesApi.API.EndpointHandlers;
using FilmesApi.API.Repo.Contexts;
using FilmesApi.Repo;
using FilmesApi.Repo.Contracts;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace FilmesApi.API;

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

        builder.Services.AddScoped<IDiretorRepository, DiretorRepository>();
        builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

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

        app.MapDiretorEndpoints();
        app.MapFilmeEndpoints();

        app.Run();
    }
}   