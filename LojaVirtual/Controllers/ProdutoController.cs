using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class ProdutoController: Controller
    {
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
