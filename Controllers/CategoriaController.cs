using AspNetCoreHero.ToastNotification.Abstractions;
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
            ViewBag.ListaCategoria = _service.ListarCategorias().OrderBy(c=> c.Descricao);
            return View(ViewBag.ListaCategoria);
        }       
    }
}
