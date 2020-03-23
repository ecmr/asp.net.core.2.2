using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Controllers
{
    public class ProdutoController: Controller
    {
        private ICategoriaRepository _categoriaRepository;
        private IProdutoRepository _produtoRepository;

        public ProdutoController(ICategoriaRepository categoriaRepository, IProdutoRepository produtoRepository)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
        }


        [HttpGet]
        [Route("Produto/Categoria/{slug}")]
        public IActionResult ListarCategoria(string slug)
        {
            Categoria categoriaPrincial = _categoriaRepository.ObterCategoria(slug);
            List<Categoria> listaCategorias = _categoriaRepository.ObterCategoriasRecursivas(categoriaPrincial).ToList();
            ViewBag.Categorias = listaCategorias;
            return View();
        }






        public ActionResult Visualizar()
        {
            Produto produto = GetProduto();
            return View(produto);
        }

        private Produto GetProduto()
        {
            return new Produto() { id = 33, Nome = "Manteiga do Marlon", Descricao = "Vai que vai", Valor = 69.69M };
        }
    }
}
