using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class ClienteController : Controller
    {
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index(int? pagina, string pesquisa)
        {
            IPagedList<Cliente> clientes = _clienteRepository.ObterTodosClientes(pagina, pesquisa);
            return View();
        }

        public IActionResult AtivarDesativar()
        {
            return View();
        }
    }
}