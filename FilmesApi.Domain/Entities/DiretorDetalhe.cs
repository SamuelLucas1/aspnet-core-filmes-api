using FilmesApi.API.Domain.Entities;

namespace FilmesApi.Domain.Entities
{
    public class DiretorDetalhe
    {
        public int Id { get; set; }
        public int DiretorId { get; set; }
        public string Biografia { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public Diretor Diretor { get; set; }
    }
}   