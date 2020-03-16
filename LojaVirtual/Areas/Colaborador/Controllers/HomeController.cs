using LojaVirtual.Libraries.Filtro;
using LojaVirtual.Libraries.Login;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class HomeController : Controller
    {
        private IColaboradorRepository _repositoryColaborador;
        private LoginColaborador _loginColaborador;

        public HomeController(IColaboradorRepository colaboradorRepository, LoginColaborador loginColaborador)
        {
            _repositoryColaborador = colaboradorRepository;
            _loginColaborador = loginColaborador;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// ValidateAntiForgeryToken é usado par proteção de CRRF - invação de sites externos
        /// Está configurado em Libraries Middleware
        /// </summary>
        /// <param name="colaborador"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([FromForm]Models.Colaborador colaborador)
        {
            Models.Colaborador _colaboradorDB = _repositoryColaborador.Login(colaborador.Email, colaborador.Senha);

            if (_colaboradorDB != null)
            {
                _loginColaborador.Login(_colaboradorDB);

                return new RedirectResult(Url.Action(nameof(Painel)));
            }
            else
            {
                ViewData["msg_Error"] = "Usuário não localizado, verifique e-mail e senha!";
                return View();
                //return new ContentResult() { Content = "Não Logado" };
            }
        }

        [ColaboradorAutorizacao]
        [ValidateHttpRefererAttribute]
        public IActionResult Logout()
        {
            _loginColaborador.Logout();
            return RedirectToAction("Login", "Home");
        }

        public IActionResult RecuperarSenha()
        {
            return View();
        }

        public IActionResult CadastrarSenha()
        {
            return View();
        }

        [ColaboradorAutorizacao]
        public IActionResult Painel()
        {
            return View();
        }
    }
}