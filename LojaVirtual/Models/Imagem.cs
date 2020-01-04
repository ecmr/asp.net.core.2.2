using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models
{
    public class Imagem
    {
        public int Id { get; set; }

        public string Caminho { get; set; }

        //Bando de Dados
        public int ProdutoId { get; set; }

        //POO
        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }

    }
}
