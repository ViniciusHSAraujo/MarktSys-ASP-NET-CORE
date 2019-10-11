using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarktSys_ASP_NET_CORE.Data;
using MarktSys_ASP_NET_CORE.DTO;
using MarktSys_ASP_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarktSys_ASP_NET_CORE.Controllers{

    [Route("api/[controller]")]
    public class VendaController : ControllerBase {

        public readonly ApplicationDbContext database;

        public VendaController(ApplicationDbContext database) {
            this.database = database;
        }

        public IActionResult Get(string options) {
            return Ok(database.Vendas.ToList());
        }
        [HttpPost]
        public IActionResult Post([FromBody] VendaDTO dados) {

            Venda venda = new Venda {
                ValorTotal = dados.Total,
                ValorDoTroco = dados.Troco,
                ValorPago = 
                    dados.Troco <= 0.01f 
                    ? dados.Total 
                    : dados.Total + dados.Troco,
                DataDaVenda = DateTime.Now
            };
            database.Vendas.Add(venda);

            database.SaveChanges();

            foreach (var produto in dados.Produtos) {

                Saida saida = new Saida() {
                    Produto = database.Produtos.First(p => p.Id == produto.Produto),
                    Quantidade = produto.Quantidade,
                    ValorDaVenda = produto.SubTotal,
                    DataDaVenda = DateTime.Now,
                    Venda = venda
                };
                database.Saidas.Add(saida);
            }

            database.SaveChanges();

            return Ok();
        }
    }
}