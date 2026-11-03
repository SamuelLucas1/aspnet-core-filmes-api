using FilmesApi.API.Domain.Entities;
using FilmesApi.API.Repo.Contexts;
using FilmesApi.Repo.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Repo
{
    public class DiretorRepository(Context _context) : IDiretorRepository
    {
        public Context Context { get; set; } = _context;

        public IEnumerable<Diretor> GetDiretores()
        {
            return Context.Diretores.Include(diretor => diretor.Filmes).ToList();
        }

        public Diretor GetDiretorByName(string name)
        {
            return Context.Diretores
                .Include(diretor => diretor.Filmes)
                .FirstOrDefault(diretor => diretor.Name.Contains(name))
                ?? new Diretor { Id = 0, Name = "Nao existe esse nome" };
        }

        public IEnumerable<Diretor> GetDiretorById(int id)
        {
            return Context.Diretores
                .Where(diretor => diretor.Id == id)
                .Include(diretor => diretor.Filmes)
                .ToList();
        }

        public void Add(Diretor diretor)
        {
            Context.Diretores.Add(diretor);
        }

        public void Delete(int diretorId)
        {
            var diretor = Context.Diretores.Find(diretorId);

            if (diretor != null)
                Context.Diretores.Remove(diretor);
        }

        public void Update(Diretor diretorNovo)
        {
            var diretor = Context.Diretores.Find(diretorNovo.Id);

            if (diretor != null)
            {
                diretor.Name = diretorNovo.Name;
                if (diretorNovo.Filmes.Count > 0)
                {
                    diretor.Filmes.Clear();
                    foreach (var filme in diretorNovo.Filmes)
                    {
                        diretor.Filmes.Add(filme);
                    }
                }
            }
        }

        public bool SaveChanges()
        {
           return Context.SaveChanges() > 0;
        }
    }
}