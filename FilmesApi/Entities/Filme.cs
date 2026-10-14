namespace FilmesApi.Entities
{
    public class Filme
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int Year { get; set; }
        public  int DiretorId { get; set; }
        public required Diretor Diretor { get; set; }
    }
}