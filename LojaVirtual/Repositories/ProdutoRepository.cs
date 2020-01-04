using LojaVirtual.DataBase;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using X.PagedList;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private IConfiguration _conf;
        LojaVirtualContext _banco;
        public ProdutoRepository(LojaVirtualContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;
        }

        public void Atualizar(Produto produto)
        {
            _banco.Update(produto);
            _banco.SaveChanges();
        }

        public void Cadastrar(Produto produto)
        {
            _banco.Add(produto);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            Produto produto = ObterProduto(id);
            _banco.Remove(produto);
            _banco.SaveChanges();
        }

        public Produto ObterProduto(int id)
        {
            return _banco.Produtos.Include(p => p.Imagens).Where(p=>p.id == id).FirstOrDefault();
        }

        public IPagedList<Produto> ObterTodosProdutos(int? pagina, string pesquisa)
        {
            int RegistroPorPagina = _conf.GetValue<int>("RegistroPorPagina");

            int NumeroPagina = pagina ?? 1;

            var bancoProduto = _banco.Produtos.AsQueryable();
            if (!string.IsNullOrEmpty(pesquisa))
            {
                bancoProduto = bancoProduto.Where(c => c.Nome.Contains(pesquisa.Trim()));
            }

            return bancoProduto.Include(p => p.Imagens).ToPagedList<Produto>(NumeroPagina, RegistroPorPagina);

        }
    }
}
