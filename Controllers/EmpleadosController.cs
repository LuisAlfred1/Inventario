using Inventario.Data;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly AppDbContext repositorioEmpleados;
        public EmpleadosController(AppDbContext context)
        {
            repositorioEmpleados = context;
        }

        [HttpGet]
        public async Task<IActionResult> IndexE()
        {
            var empleados = await repositorioEmpleados.Empleados.ToListAsync();
            return View(empleados);

        }

        [HttpGet]
        public IActionResult agregarEmpleado()
        {
            return View(); // Retorna la vista del formulario para agregar cliente
        }


        [HttpPost]
        public async Task<IActionResult> agregarEmpleado(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                repositorioEmpleados.Add(empleado);
                await repositorioEmpleados.SaveChangesAsync();
                return RedirectToAction(nameof(IndexE));
            }
            return View();
        }
    }
}
