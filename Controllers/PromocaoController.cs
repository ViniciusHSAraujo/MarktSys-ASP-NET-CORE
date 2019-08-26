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

            if (ModelState.IsValid && promocaoDTO.ProdutosSelecionados.Count > 0) {

                Promocao promocao = new Promocao() {
                    PercentualDesconto = promocaoDTO.PercentualDesconto,
                    DataInicio = promocaoDTO.DataInicio,
                    DataFinal = promocaoDTO.DataFinal,
                    Produtos = new List<Produto>(),
                    PromocaoProdutos = new List<PromocaoProduto>()
                };

                foreach (var codigo in promocaoDTO.ProdutosSelecionados) {
                    promocao.Produtos.Add(database.Produtos.First(p => p.Id == codigo));
                }

                foreach (var produto in promocao.Produtos) {
                    PromocaoProduto promocaoProduto = new PromocaoProduto() {
                        Promocao = promocao,
                        Produto = produto,
                    };
                    promocao.PromocaoProdutos.Add(promocaoProduto);
                }

                database.Promocoes.Add(promocao);
                database.SaveChanges();

            } else {
                return View("../administrativo/novapromocao");
            }

            return RedirectToAction("Promocoes", "Administrativo");
        }

/*          public IActionResult Teste() {
            var promocao = new Promocao { PercentualDesconto = 10, DataInicio = DateTime.Now, DataFinal = DateTime.Now.AddDays(10), Produtos = new List<Produto>(), PromocaoProdutos = new List<PromocaoProduto>() };

            Produto p1 = database.Produtos.First(p => p.Id == 4);
            Produto p2 = database.Produtos.First(p => p.Id == 5);
            Produto p3 = database.Produtos.First(p => p.Id == 6);

            promocao.Produtos.Add(p1);
            promocao.Produtos.Add(p2);
            promocao.Produtos.Add(p3);

            foreach (var produto in promocao.Produtos) {
                PromocaoProduto promocaoProduto = new PromocaoProduto() {
                    Promocao = promocao,
                    Produto = produto
                };
                promocao.PromocaoProdutos.Add(promocaoProduto);
            }
            database.Promocoes.Add(promocao);
            database.SaveChanges();

            return Content("Teste realizado com sucesso");
        }*/
    }
}