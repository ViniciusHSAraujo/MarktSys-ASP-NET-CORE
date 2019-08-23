using MarktSys_ASP_NET_CORE.Data;
using MarktSys_ASP_NET_CORE.DTO;
using MarktSys_ASP_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MarktSys_ASP_NET_CORE.Controllers {
    public class AdministrativoController : Controller {

        public readonly ApplicationDbContext database;

        public AdministrativoController(ApplicationDbContext database) {
            this.database = database;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Categorias() {
            var listaCategorias = database.Categorias.Where(c => c.Status).ToList();

            return View(listaCategorias);
        }
        public IActionResult NovaCategoria() {
            return View();
        }

        public IActionResult EditarCategoria(int id) {
            Categoria categoria = database.Categorias.First(c => c.Id == id);

            CategoriaDTO categoriaDTO = new CategoriaDTO() {
                Id = categoria.Id,
                Nome = categoria.Nome,
            };


            return View(categoriaDTO);
        }

        public IActionResult Fornecedores() {
            var listaFornecedores = database.Fornecedores.Where(f => f.Status).ToList();
            return View(listaFornecedores);
        }
        public IActionResult NovoFornecedor() {
            return View();
        }

        public IActionResult EditarFornecedor(int id) {
            Fornecedor fornecedor = database.Fornecedores.First(f => f.Id == id);

            FornecedorDTO fornecedorDTO = new FornecedorDTO() {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                Email = fornecedor.Email,
                Telefone = fornecedor.Telefone
            };


            return View(fornecedorDTO);
        }
        public IActionResult Unidades() {
            var listaUnidades = database.Unidades.Where(u => u.Status).ToList();
            return View(listaUnidades);
        }
        public IActionResult NovaUnidade() {
            return View();
        }
        public IActionResult EditarUnidade(int id) {
            Unidade unidade = database.Unidades.First(u => u.Id == id);

            UnidadeDTO unidadeDTO = new UnidadeDTO() {
                Id = unidade.Id,
                Nome = unidade.Nome,
                Simbolo = unidade.Simbolo
            };


            return View(unidadeDTO);
        }

        public IActionResult Produtos() {
            var listaProdutos = database.Produtos.Include(p => p.Categoria).Include(p => p.Unidade).Include(p => p.Fornecedor).Where(p => p.Status).ToList();
            return View(listaProdutos);
        }
        public IActionResult NovoProduto() {

            ViewBag.categorias = database.Categorias.Where(c => c.Status).ToList();
            ViewBag.unidades = database.Unidades.Where(u => u.Status).ToList();
            ViewBag.fornecedores = database.Fornecedores.Where(f => f.Status).ToList();

            return View();
        }

        public IActionResult EditarProduto(int id) {

            ViewBag.categorias = database.Categorias.Where(c => c.Status).ToList();
            ViewBag.unidades = database.Unidades.Where(u => u.Status).ToList();
            ViewBag.fornecedores = database.Fornecedores.Where(f => f.Status).ToList();

            Produto produto = database.Produtos.Include(p => p.Categoria).Include(p => p.Fornecedor).Include(p => p.Unidade).First(p => p.Id == id);

            ProdutoDTO produtoDTO = new ProdutoDTO() {
                Id = produto.Id,
                Nome = produto.Nome,
                CategoriaID = produto.Categoria.Id,
                FornecedorID = produto.Fornecedor.Id,
                UnidadeID = produto.Unidade.Id,
                PrecoCusto = produto.PrecoCusto,
                PrecoVenda = produto.PrecoVenda
            };
            return View(produtoDTO);
        }

        public IActionResult Promocoes() {
            var listaPromocoes = database.Promocoes.ToList();
            return View(listaPromocoes);
        }

        public IActionResult NovaPromocao() {
            ViewBag.produtos = database.Produtos.Where(c => c.Status).ToList();
            return View();
        }

        public IActionResult Estoque() {
            var listaEstoques = database.Estoques.Include(e => e.Produto).ToList();
            return View(listaEstoques);
        }

        public IActionResult NovoEstoque() {
            ViewBag.produtos = database.Produtos.Where(c => c.Status).ToList();
            return View();
        }
        public IActionResult EditarEstoque() {

            return View();
        }
    }
}