﻿using LojaVirtual.Libraries.Arquivo;
using LojaVirtual.Libraries.Lang;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class ProdutoController : Controller
    {
        private IProdutoRepository _produtoRepository;
        private ICategoriaRepository _categoriaRepository;
        private IImagemRepository _imagemRepository;
        public ProdutoController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository, IImagemRepository imagemRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _imagemRepository = imagemRepository;
        }

        public IActionResult Index(int? pagina, string pesquisa)
        {
            var produtos = _produtoRepository.ObterTodosProdutos(pagina, pesquisa);
            return View(produtos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(c=> new SelectListItem(c.Nome, string.Concat(c.Id)));
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            if(ModelState.IsValid)
            {
                _produtoRepository.Cadastrar(produto);
                List<Imagem> CaminhoLista =  GerenciadorArquivo.MoverImagensProduto(new List<string>(Request.Form["imagem"]), produto.id);

                _imagemRepository.CadastrarImagem(CaminhoLista, produto.id);

                TempData["MSG_S"] = Mensagem.MSG_S001;
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(c => new SelectListItem(c.Nome, string.Concat(c.Id)));
            return View();
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(c => new SelectListItem(c.Nome, string.Concat(c.Id)));
            Produto produto = _produtoRepository.ObterProduto(id);

            return View(produto);
        }

        [HttpPost]
        public IActionResult Atualizar(Produto produto, int id)
        {
            if (ModelState.IsValid)
            {
                _produtoRepository.Atualizar(produto);

                TempData["MSG_S"] = Mensagem.MSG_S001;
            }

            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(c => new SelectListItem(c.Nome, string.Concat(c.Id)));
            return View(produto);
        }
    }
}