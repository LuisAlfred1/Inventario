using Inventario.Data;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AppDbContext repositorioCategorias;
        public CategoriasController(AppDbContext context)
        {
            repositorioCategorias = context;
        }

        [HttpGet]
        public async Task<IActionResult> IndexC()
        {
            var categorias = await repositorioCategorias.Categorias.ToListAsync();
            return View(categorias);

        }

        [HttpGet]
        public IActionResult agregarCategoria()
        {
            return View(); // Retorna la vista del formulario para agregar cliente
        }


        [HttpPost]
        public async Task<IActionResult> agregarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                repositorioCategorias.Add(categoria);
                await repositorioCategorias.SaveChangesAsync();
                return RedirectToAction(nameof(IndexC));
            }
            return View();
        }
    }
}
