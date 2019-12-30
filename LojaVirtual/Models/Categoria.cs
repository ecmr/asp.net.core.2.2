using LojaVirtual.Libraries.Lang;
using LojaVirtual.Libraries.Sessao;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models
{
    public class Categoria
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E002")]
        //TODO - Criar validação de nome Categoria unico no banco.
        public string Nome { get; set; }

        /*
         *   URL Nomral: www.lojavirtual.com.br/categoria/4
         * URL Amigável: irtual.com.br/categoria/informatica
         *Slug:
         */
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E002")]
        public string Slug { get; set; }

        /*
         * Auto-Relacionamento
         * 1 - Informática     - P:null
         * - 2 - Mouse         - P:1
         * - 3 - Mouse sem fio - P:2
         * - 4 - Mouse Gamer   - P:3
         */
        [Display(Name = "Categoria Pai")]
        public int? CategoriaPaiId { get; set; }

        /*
         * ORM - EntityFrameworkCore
         */
        
        [ForeignKey("CategoriaPaiId")]
        public virtual Categoria CategoriaPai { get; set; }


    }
}
