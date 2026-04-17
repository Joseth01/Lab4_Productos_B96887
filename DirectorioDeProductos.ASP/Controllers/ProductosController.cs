using DirectorioDeProductos.ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace DirectorioDeProductos.ASP.Controllers
{
    public class ProductosController : Controller
    {
        private ProductoRepositorio repositorio = new ProductoRepositorio();
        public IActionResult Index()
        {
            var lista = repositorio.ObtenerTodos();
            return View(lista);
        }
        public IActionResult Detalles(int id)
        {
            var producto = repositorio.ObtenerPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Producto producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            repositorio.Agregar(producto);
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            var producto = repositorio.ObtenerPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(Producto producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            repositorio.Actualizar(producto);
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(int id)
        {
            var producto = repositorio.ObtenerPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpPost]
        public IActionResult EliminarConfirmado(int id)
        {
            repositorio.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
