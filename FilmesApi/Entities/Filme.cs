namespace FilmesApi.Entities
{
    public class Filme
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int Year { get; set; }
        public Diretor? Diretor { get; set; }
    }
}