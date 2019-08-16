using MarktSys_ASP_NET_CORE.Data;
using MarktSys_ASP_NET_CORE.DTO;
using MarktSys_ASP_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MarktSys_ASP_NET_CORE.Controllers {
    public class UnidadeController : Controller {

        public readonly ApplicationDbContext database;

        public UnidadeController(ApplicationDbContext database) {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(UnidadeDTO unidadeDTO) {

            if (ModelState.IsValid) {
                Unidade unidade = new Unidade() {
                    Nome = unidadeDTO.Nome,
                    Simbolo = unidadeDTO.Simbolo,
                    Status = true
                };

                database.Unidades.Add(unidade);
                database.SaveChanges();
            } else {
                return View("../administrativo/novaunidade");
            }

            return RedirectToAction("Unidades", "Administrativo");
        }

        [HttpPost]
        public IActionResult Editar(UnidadeDTO unidadeDTO) {

            if (ModelState.IsValid) {

                Unidade unidadeBanco = database.Unidades.First(u => u.Id == unidadeDTO.Id);

                unidadeBanco.Nome = unidadeDTO.Nome;
                unidadeBanco.Simbolo = unidadeDTO.Simbolo;

                database.SaveChanges();
            } else {
                return View("../administrativo/novaunidade");
            }

            return RedirectToAction("Unidades", "Administrativo");
        }

        [HttpPost]
        public IActionResult Inativar(int id) {

            Unidade unidadeBanco = database.Unidades.First(u => u.Id == id);
            unidadeBanco.Status = false;
            database.SaveChanges();

            return RedirectToAction("Unidades", "Administrativo");
        }
    }
}