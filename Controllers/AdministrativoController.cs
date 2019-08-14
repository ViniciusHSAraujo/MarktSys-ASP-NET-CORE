using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarktSys_ASP_NET_CORE.Data;
using Microsoft.AspNetCore.Mvc;

namespace MarktSys_ASP_NET_CORE.Controllers
{
    public class AdministrativoController : Controller{

        public readonly ApplicationDbContext database;

        public AdministrativoController(ApplicationDbContext database) {
            this.database = database;
        }

        public IActionResult Index(){
            return View();
        }

        public IActionResult Categorias() {
            var listaCategorias = database.Categorias.Where(c => c.Status).ToList();

            return View(listaCategorias);
        }
        public IActionResult NovaCategoria() {
            return View();
        }

        public IActionResult Fornecedores() {
            var listaFornecedores = database.Fornecedores.ToList();
            return View(listaFornecedores);
        }
        public IActionResult NovoFornecedor() {
            return View();
        }

    }
}