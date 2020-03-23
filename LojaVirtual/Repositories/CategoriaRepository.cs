using LojaVirtual.DataBase;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private IConfiguration _conf;
        LojaVirtualContext _banco;
        public CategoriaRepository(LojaVirtualContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;
        }

        public void Atualizar(Categoria categoria)
        {
            _banco.Update(categoria);
            _banco.SaveChanges();
        }

        public void Cadastrar(Categoria categoria)
        {
            _banco.Add(categoria);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Categoria categoria = ObterCategoria(Id);
            _banco.Remove(categoria);
            _banco.SaveChanges();
        }

        public Categoria ObterCategoria(int Id)
        {
            return _banco.Categorias.Find(Id);
        }

        public Categoria ObterCategoria(string slug)
        {
            return _banco.Categorias.Where(c => c.Slug == slug).FirstOrDefault();
        }

        private List<Categoria> Categorias;
        private List<Categoria> ListaCategorias = new List<Categoria>();
        public IEnumerable<Categoria> ObterCategoriasRecursivas(Categoria categoriaPai)
        {
            if (Categorias == null)
            {
                Categorias = ObterTodasCategorias().ToList();
            }
            if (!ListaCategorias.Exists(c => c.Id == categoriaPai.Id))
            {
                ListaCategorias.Add(categoriaPai);
            }
            var ListaCategoriasFilho = Categorias.Where(c => c.CategoriaPaiId == categoriaPai.Id);
            if (ListaCategoriasFilho.Any())
            {
                ListaCategorias.AddRange(ListaCategoriasFilho.ToList());
                foreach (var categoria in ListaCategoriasFilho)
                {
                    ObterCategoriasRecursivas(categoria);
                }
            }
            return ListaCategorias;
        }

        public IPagedList<Categoria> ObterTodasCategorias(int? pagina)
        {
            int NumeroPagina = pagina ?? 1;
            
            return _banco.Categorias.Include(c=> c.CategoriaPai).ToPagedList<Categoria>(NumeroPagina, _conf.GetValue<int>("RegistroPorPagina"));
        }

        public IEnumerable<Categoria> ObterTodasCategorias()
        {
            return _banco.Categorias;
        }
    }
}
