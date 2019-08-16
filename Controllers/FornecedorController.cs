using MarktSys_ASP_NET_CORE.Data;
using MarktSys_ASP_NET_CORE.DTO;
using MarktSys_ASP_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarktSys_ASP_NET_CORE.Controllers {
    public class FornecedorController : Controller {

        public readonly ApplicationDbContext database;

        public FornecedorController(ApplicationDbContext database) {
            this.database = database;
        }

        public IActionResult Salvar(FornecedorDTO fornecedorDTO) {

            if (ModelState.IsValid) {
                Fornecedor fornecedor = new Fornecedor() {
                    Nome = fornecedorDTO.Nome,
                    Email = fornecedorDTO.Email,
                    Telefone = fornecedorDTO.Telefone,
                    Status = true
                };

                database.Fornecedores.Add(fornecedor);
                database.SaveChanges();
            } else {
                return View("../administrativo/novofornecedor");
            }

            return RedirectToAction("Fornecedores", "Administrativo");
        }
    }
}