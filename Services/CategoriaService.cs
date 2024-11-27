using ControleFinanceiro.Data;
using ControleFinanceiro.Models;

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
            var categoria = _context.Categorias.First(c=> c.Descricao == nome);
            return categoria;
        }
    }
}
