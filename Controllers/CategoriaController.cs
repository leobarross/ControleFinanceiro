using AspNetCoreHero.ToastNotification.Abstractions;
using ControleFinanceiro.Models;
using ControleFinanceiro.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaService _service;
        private readonly INotyfService _notyfService;

        public CategoriaController(CategoriaService service, INotyfService notyfService)
        {
            _service = service;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            string filtro = Request.Query["Filtro"].ToString();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                ViewBag.ListaCategoria = _service.ListarCategorias().OrderBy(c => c.Descricao).ToList();
            }
            else
            {
                var categoria = _service.BuscarCategoriaPorNome(filtro);
                ViewBag.ListaCategoria = categoria != null ? [categoria] : new List<Categoria>();
            }

            return View(ViewBag.ListaCategoria);
        }

        public JsonResult BuscarCategoria(string id)
        {
            var categora = _service.BuscarPorId(id);

            return Json(categora);
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Gravar(Categoria categoria)
        {
           var categoriaExiste = _service.BuscarCategoriaPorNome(categoria.Descricao);

            if(categoriaExiste != null)
            {
                _notyfService.Error("Já existe uma categoria com esse nome");
                return RedirectToAction(nameof(Index));
            }

            if (string.IsNullOrEmpty(categoria.Id))
            {
                categoria.Id = Guid.NewGuid().ToString();
                _service.InsertCategoria(categoria);
                _notyfService.Success("Categoria Incluida com sucesso");            
            }
            else
            {
                _service.UpdateCategoria(categoria);
                _notyfService.Success("Categoria Alterada com sucesso");              
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(string id)
        {
            var categoriaExiste = _service.BuscarPorId(id);

            if(categoriaExiste != null)
            {
                _service.DeleteCategoria(id);
                _notyfService.Success("Categoria Excluida com Sucesso");
            }
            else
            {
                _notyfService.Error("Houve um erro ao tentar excluir, por favor tente novamente");
            }

            return RedirectToAction(nameof(Index));
        }

       
    }
}
