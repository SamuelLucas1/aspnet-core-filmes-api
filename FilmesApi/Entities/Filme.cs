namespace FilmesApi.Entities
{
    public class Filme
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int DiretorId { get; set; }
        public Diretor Diretor { get; set; } = null!;
    }
}