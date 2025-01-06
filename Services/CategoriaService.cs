using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.IdentityModel.Tokens;

namespace ControleFinanceiro.Services
{
    public class CategoriaService
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public List<Categoria> ListarCategorias()
        {
            var listaCategoria = _context.Categorias.ToList();

            return listaCategoria;
        }

        public Categoria BuscarCategoriaPorNome(string nome)
        {

            if (string.IsNullOrEmpty(nome))
            {
                return null;
            }

            return _context.Categorias.FirstOrDefault(c => c.Descricao == nome);
        }

        public Categoria BuscarPorId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            return _context.Categorias.Find(id);
        }

        public void InsertCategoria(Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();
        }

        public void UpdateCategoria(Categoria categoria)
        {
            _context.Update(categoria);
            _context.SaveChanges();
        }

        public void DeleteCategoria(string id)
        {
            var categoria = _context.Categorias.Find(id);

            if (categoria != null)
            {
                _context.Remove(categoria);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Categoria não encontrada.");
            }
        }
    }
}
