using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarktSys_ASP_NET_CORE.Data;
using MarktSys_ASP_NET_CORE.DTO;
using MarktSys_ASP_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarktSys_ASP_NET_CORE.Controllers
{
    public class CategoriaController : Controller
    {

        public readonly ApplicationDbContext database;

        public CategoriaController(ApplicationDbContext database) {
            this.database = database;
        }

        public IActionResult Index(){
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(CategoriaDTO categoriaDTO) {

            if (ModelState.IsValid) {
                Categoria categoria = new Categoria() {
                    Nome = categoriaDTO.Nome,
                    Status = true
                };

                database.Add(categoria);
                database.SaveChanges();
            } else {
                return View("../administrativo/novacategoria");
            }

            return RedirectToAction("Categorias", "Administrativo");
        }
    }
}