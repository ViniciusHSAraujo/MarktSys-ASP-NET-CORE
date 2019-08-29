using MarktSys_ASP_NET_CORE.Data;
using MarktSys_ASP_NET_CORE.DTO;
using MarktSys_ASP_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace MarktSys_ASP_NET_CORE.Controllers {
    public class ProdutoController : Controller {
        public readonly ApplicationDbContext database;

        public ProdutoController(ApplicationDbContext database) {
            this.database = database;
        }

        public IActionResult Salvar(ProdutoDTO produtoDTO) {
            if (ModelState.IsValid) {
                Produto produto = new Produto() {
                    Nome = produtoDTO.Nome,
                    Categoria = database.Categorias.First(c => c.Id == produtoDTO.CategoriaID),
                    Unidade = database.Unidades.First(u => u.Id == produtoDTO.UnidadeID),
                    Fornecedor = database.Fornecedores.First(f => f.Id == produtoDTO.FornecedorID),
                    PrecoCusto = float.Parse(produtoDTO.PrecoCustoString, CultureInfo.InvariantCulture.NumberFormat),
                    PrecoVenda = float.Parse(produtoDTO.PrecoVendaString, CultureInfo.InvariantCulture.NumberFormat),
                    Status = true
                };
                database.Produtos.Add(produto);
                database.SaveChanges();
            } else {
                ViewBag.categorias = database.Categorias.ToList();
                ViewBag.unidades = database.Unidades.ToList();
                ViewBag.fornecedores = database.Fornecedores.ToList();

                return View("../administrativo/novoproduto");
            }
            return RedirectToAction("Produtos", "Administrativo");
        }

        [HttpPost]
        public IActionResult Editar(ProdutoDTO produtoDTO) {

            if (ModelState.IsValid) {

                Produto produtoBanco = database.Produtos.First(p => p.Id == produtoDTO.Id);

                produtoBanco.Nome = produtoDTO.Nome;
                produtoBanco.PrecoCusto = float.Parse(produtoDTO.PrecoCustoString, CultureInfo.InvariantCulture.NumberFormat);
                produtoBanco.PrecoVenda = float.Parse(produtoDTO.PrecoVendaString, CultureInfo.InvariantCulture.NumberFormat) ;
                produtoBanco.Categoria = database.Categorias.First(c => c.Id == produtoDTO.CategoriaID);
                produtoBanco.Fornecedor = database.Fornecedores.First(f => f.Id == produtoDTO.FornecedorID);
                produtoBanco.Unidade = database.Unidades.First(u => u.Id == produtoDTO.UnidadeID);

                database.SaveChanges();
            } else {
                return View("../administrativo/novoproduto");
            }

            return RedirectToAction("Produtos", "Administrativo");
        }

        [HttpPost]
        public IActionResult Inativar(int id) {

            Produto produtoBanco = database.Produtos.First(p => p.Id == id);
            produtoBanco.Status = false;
            database.SaveChanges();

            return RedirectToAction("Produtos", "Administrativo");
        }

        [HttpPost]
        public IActionResult Produto(int id) {

            if (id > 0) {
                try {

                    Produto produto = database.Produtos.Where(p => p.Status).Include(p => p.Categoria).Include(p => p.Unidade).Include(p => p.Fornecedor).First(p => p.Id == id);

                    var qtdeEntradas = database.Estoques.Include(p => p.Produto).AsEnumerable().Where(e => e.Produto.Id == id).Sum(e => e.Saldo);
                    var qtdeSaidas = database.Saidas.Include(p => p.Produto).AsEnumerable().Where(e => e.Produto.Id == id).Sum(e => e.Quantidade);
                    var qtdeEstoque = qtdeEntradas - qtdeSaidas;

                    var promocao = database.Promocoes.Include(pr => pr.PromocaoProdutos).ThenInclude(pp => pp.Produto).Where(pr => pr.DataInicio < DateTime.Now && pr.DataFinal > DateTime.Now && pr.Produtos.Contains(produto)).LastOrDefault();

                    if (qtdeEstoque <= 0) {
                        throw new Exception("Produto sem saldo!");
                    }

                    if(promocao != null) {
                        produto.PrecoVenda = produto.PrecoVenda * (float)(1 - Convert.ToDouble(promocao.PercentualDesconto) / 100);
                        produto.PromocaoProdutos = null;
                    }

                Response.StatusCode = 200;

                    return Json(new { produto = produto, saldo = qtdeEstoque });
                } catch {
                    return NotFound();
                }
            } else {
                Response.StatusCode = 406;
                return new ObjectResult("");
            }


        }
    }
}