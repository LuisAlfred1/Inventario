using Inventario.Data;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Inventario.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AppDbContext repositorioClientes;
        public ClientesController(AppDbContext context)
        {
            repositorioClientes = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientes = await repositorioClientes.Clientes.ToListAsync();
            return View(clientes);

        }

        [HttpGet]
        public IActionResult agregarCliente()
        {
            return View(); // Retorna la vista del formulario para agregar cliente
        }


        [HttpPost]
        public async Task<IActionResult> agregarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                repositorioClientes.Add(cliente);
                await repositorioClientes.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
