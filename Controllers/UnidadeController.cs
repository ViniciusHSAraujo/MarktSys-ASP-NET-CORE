using MarktSys_ASP_NET_CORE.Data;
using MarktSys_ASP_NET_CORE.DTO;
using MarktSys_ASP_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}