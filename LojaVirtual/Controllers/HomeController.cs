using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LojaVirtual.DataBase;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private LojaVirtualContext _banco;
        private readonly ILogger<HomeController> _logger;

        public HomeController(LojaVirtualContext banco,ILogger<HomeController> logger)
        {
            _banco = banco;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error: " + ex.Message.ToString());
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm]NewsLetterEmail newsLetter)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _banco.NewsLetterEmails.Add(newsLetter);
                    _banco.SaveChanges();

                    TempData["MSG_S"] = "Email cadastrado, você receberá nossas promossões!";


                    RedirectToAction("Index");
                }
                else
                {
                    return View();
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
                    ContatoEmail.EnviarContatoPorEmail(contato);
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

        public IActionResult Login()
        {
            return View();
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