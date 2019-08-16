using MarktSys_ASP_NET_CORE.Data;
using MarktSys_ASP_NET_CORE.DTO;
using MarktSys_ASP_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Unidades() {
            var listaUnidades = database.Unidades.Where(u => u.Status).ToList();
            return View(listaUnidades);
        }
        public IActionResult NovaUnidade() {
            return View();
        }

        public IActionResult Produtos() {
            var listaProdutos = database.Produtos.Where(p => p.Status).ToList();
            return View(listaProdutos);
        }
        public IActionResult NovoProduto() {

            ViewBag.categorias = database.Categorias.ToList();
            ViewBag.unidades = database.Unidades.ToList();
            ViewBag.fornecedores = database.Fornecedores.ToList();

            return View();
        }
    }
}