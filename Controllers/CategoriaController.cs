using MarktSys_ASP_NET_CORE.Data;
using MarktSys_ASP_NET_CORE.DTO;
using MarktSys_ASP_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MarktSys_ASP_NET_CORE.Controllers {
    public class CategoriaController : Controller {

        public readonly ApplicationDbContext database;

        public CategoriaController(ApplicationDbContext database) {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(CategoriaDTO categoriaDTO) {

            if (ModelState.IsValid) {
                Categoria categoria = new Categoria() {
                    Nome = categoriaDTO.Nome,
                    Status = true
                };

                database.Categorias.Add(categoria);
                database.SaveChanges();
            } else {
                return View("../administrativo/novacategoria");
            }

            return RedirectToAction("Categorias", "Administrativo");
        }

        [HttpPost]
        public IActionResult Editar(CategoriaDTO categoriaDTO) {

            if (ModelState.IsValid) {

                Categoria categoriaBanco = database.Categorias.First(c => c.Id == categoriaDTO.Id);

                categoriaBanco.Nome = categoriaDTO.Nome;

                database.SaveChanges();
            } else {
                return View("../administrativo/novacategoria");
            }

            return RedirectToAction("Categorias", "Administrativo");
        }

        [HttpPost]
        public IActionResult Inativar(int id) {

            Categoria categoriaBanco = database.Categorias.First(c => c.Id == id);
            categoriaBanco.Status = false;
            database.SaveChanges();

            return RedirectToAction("Categorias", "Administrativo");
        }
    }
}