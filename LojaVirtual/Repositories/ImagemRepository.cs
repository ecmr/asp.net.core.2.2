using LojaVirtual.DataBase;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Repositories
{
    public class ImagemRepository : IImagemRepository
    {
        private LojaVirtualContext _banco;
        public ImagemRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        public void CadastrarImagem(List<Imagem> ImagemLista, int produtoId)
        {
            if (ImagemLista != null && ImagemLista.Count > 0)
            {
                foreach (var imagemlst in ImagemLista)
                {
                    var imagem = new Imagem() { Caminho = imagemlst.Caminho, ProdutoId = produtoId };
                    Cadastrar(imagem);
                }
            }
        }

        public void Cadastrar(Imagem imagem)
        {
            _banco.Add(imagem);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            Imagem imagem = _banco.Imagems.Find(id);
            _banco.Remove(imagem);
            _banco.SaveChanges();
        }

        public void ExcluirImagensDoProduto(int ProdutoId)
        {
            List<Imagem> imagens = _banco.Imagems.Where(i => i.ProdutoId == ProdutoId).ToList();
            foreach (Imagem imagem in imagens)
            {
                _banco.Remove(imagem);
            }
            
            _banco.SaveChanges();
        }
    }
}
