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
    public class PromocaoController : Controller{

        public readonly ApplicationDbContext database;

        public PromocaoController(ApplicationDbContext database) {
            this.database = database;
        }

        public IActionResult Salvar(PromocaoDTO promocaoDTO) {

            if (ModelState.IsValid) {
                Promocao promocao = new Promocao() {
                    PercentualDesconto = promocaoDTO.PercentualDesconto,
                    DataInicio = promocaoDTO.DataInicio,
                    DataFinal = promocaoDTO.DataFinal,
                };

                // Validação só pra não ficar enchendo o banco de dados enquanto tento ajustar o salvamento..
                if(promocao.PromocaoProdutos != null) {
                database.Promocoes.Add(promocao);
                database.SaveChanges();
                }
            } else {
                return View("../administrativo/novapromocao");
            }

            return RedirectToAction("Promocoes", "Administrativo");
        }

    }
}