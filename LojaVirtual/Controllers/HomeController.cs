using LojaVirtual.Libraries.Email;
using LojaVirtual.Libraries.Filtro;
using LojaVirtual.Libraries.Login;
using LojaVirtual.Models;
using LojaVirtual.Models.ViewModels;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private IProdutoRepository _produtoRepository;
        private readonly ILogger<HomeController> _logger;
        private IClienteRepository _repositoryCliente;
        private INewsletterRepository _repositoryNewsletter;
        private LoginCliente _loginCliente;
        private GerenciarEmail _gerenciarEmail;
        public HomeController(IProdutoRepository produtoRepository, IClienteRepository repositoryCliente, INewsletterRepository newsletterRepository, LoginCliente loginCliente, GerenciarEmail gerenciarEmail, ILogger<HomeController> logger)
        {
            _produtoRepository = produtoRepository;
            _repositoryCliente = repositoryCliente;
            _repositoryNewsletter = newsletterRepository;
            _loginCliente = loginCliente;
            _gerenciarEmail = gerenciarEmail;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index() //int? pagina, string pesquisa, string ordenacao="A"
        {
            try
            {
                //var viewModel = new IndexViewModel() { lista = _produtoRepository.ObterTodosProdutos(pagina, pesquisa, ordenacao) };
               // var viewModel = new ProdutoListagemViewModel() { lista = _produtoRepository.ObterTodosProdutos(pagina, pesquisa, ordenacao) };
               // return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error: " + ex.Message.ToString());
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm]NewsLetterEmail newsLetter) //int? pagina, string pesquisa, string ordenacao, 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositoryNewsletter.Cadastrar(newsLetter);

                    TempData["MSG_S"] = "Email cadastrado, você receberá nossas promossões!";


                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //var viewModel = new IndexViewModel() { lista = _produtoRepository.ObterTodosProdutos(pagina, pesquisa, ordenacao) };
                    // var viewModel = new ProdutoListagemViewModel() { lista = _produtoRepository.ObterTodosProdutos(pagina, pesquisa, ordenacao) };
                    // return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error: " + ex.InnerException);
                throw new Exception("Error: " + ex.InnerException);
            }
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult Categoria()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {
            Contato contato = new Contato();
            try
            {
                contato.Nome = HttpContext.Request.Form["nome"];
                contato.Email = HttpContext.Request.Form["email"];
                contato.Texto = HttpContext.Request.Form["texto"];



                var lstMsgError = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);

                if (Validator.TryValidateObject(contato, contexto, lstMsgError, true))
                {
                    _gerenciarEmail.EnviarContatoPorEmail(contato);
                    ViewData["msg_envio"] = "E-mail enviado com sucesso!";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var texto in lstMsgError)
                    {
                        sb.Append(texto.ErrorMessage + "<br />");
                    }

                    ViewData["msg_Error"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }


                return View("Contato");
            }
            catch (Exception ex)
            {
                ViewData["msg_Error"] = "Ops!...tivemos um problema, tente novamente mais tarde!";
                _logger.LogInformation("Error: " + ex.Message.ToString());
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]Cliente cliente)
        {
            Cliente _cliente = _repositoryCliente.Login(cliente.Email, cliente.Senha);

            if (_cliente != null)
            {
                _loginCliente.Login(_cliente);

                return new RedirectResult(Url.Action(nameof(Painel)));
            }
            else
            {
                ViewData["msg_Error"] = "Usuário não localizado, verifique e-mail e senha!";
                return View();
                //return new ContentResult() { Content = "Não Logado" };
            }
        }

        [HttpGet]
        [ClienteAutorizacao]
        public IActionResult Painel()
        {
            return new ContentResult() { Content = "PAINEL" };
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}