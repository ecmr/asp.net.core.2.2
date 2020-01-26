using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.Contracts
{
    public interface IImagemRepository
    {
        void CadastrarImagem(List<Imagem> CaminhoLista, int produtoId);
        void Cadastrar(Imagem imagem);

        //void Atualizar(Produto produto);
        
        void Excluir(int id);

        void ExcluirImagensDoProduto(int ProdutoId);
    }
}
