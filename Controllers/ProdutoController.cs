using MarktSys_ASP_NET_CORE.Data;
using MarktSys_ASP_NET_CORE.DTO;
using MarktSys_ASP_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
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
                    PrecoCusto = produtoDTO.PrecoCusto,
                    PrecoVenda = produtoDTO.PrecoVenda,
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
                produtoBanco.PrecoCusto = produtoDTO.PrecoCusto;
                produtoBanco.PrecoVenda = produtoDTO.PrecoVenda;
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
    }
}