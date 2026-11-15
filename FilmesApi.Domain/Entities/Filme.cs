using FilmesApi.Domain.Entities;

namespace FilmesApi.API.Domain.Entities
{
    public class Filme
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public ICollection<DiretorFilme> DiretoresFilmes { get; set; } = null!;
        public  ICollection<Diretor> Diretores { get; set; } = null!;       
    }
}       