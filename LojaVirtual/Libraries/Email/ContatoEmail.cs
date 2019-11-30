using LojaVirtual.ClassesLog;
using LojaVirtual.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        private readonly ILogger<ContatoEmail> _logger;

        public ContatoEmail(ILogger<ContatoEmail> logger)
        {
            _logger = logger;
        }

        public static void EnviarContatoPorEmail(Contato contato)
        {
            SmtpClient smtp = new SmtpClient("smtps.bol.com.br", 587);

            try
            {
                //rwvdmfnqwvcdexzp
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("edinei.correa2@bol.com.br", "VRVnE5WICvGHy6");
                smtp.EnableSsl = true;
                smtp.Port = 587;

                MailMessage message = new MailMessage();
                message.From = new MailAddress("edinei.correa2@bol.com.br");
                message.To.Add("edinei.menezes@gmail.com");
                message.Subject = "LojaVirtual-ECM";
                message.Body = string.Format("<h3>Email da lojaVirtual</h3><br/> " +
                                                 "Nome: " + contato.Nome + "<br/>" +
                                                 " Email: " + contato.Email + "<br/>" +
                                                 " texto: " + contato.Texto);
                message.IsBodyHtml = true;
                
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
                ///_logger.LogInformation("Erro ao enivar email para:" + contato.Email + " error: " + ex.Message);
            }
            
        }
    }
}
