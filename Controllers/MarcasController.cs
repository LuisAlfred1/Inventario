using Inventario.Data;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Controllers
{
    public class MarcasController : Controller
    {
        private readonly AppDbContext repositorioMarca;
        public MarcasController(AppDbContext context)
        {
            repositorioMarca = context;
        }

        [HttpGet]
        public async Task<IActionResult> IndexM()
        {
            var marcas = await repositorioMarca.Marcas.ToListAsync();
            return View(marcas);

        }

        [HttpGet]
        public IActionResult agregarMarca()
        {
            return View(); // Retorna la vista del formulario para agregar cliente
        }


        [HttpPost]
        public async Task<IActionResult> agregarMarca(Marca marca)
        {
            if (ModelState.IsValid)
            {
                repositorioMarca.Add(marca);
                await repositorioMarca.SaveChangesAsync();
                return RedirectToAction(nameof(IndexM));
            }
            return View();
        }
    }
}
