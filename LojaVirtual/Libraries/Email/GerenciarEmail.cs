using LojaVirtual.ClassesLog;
using LojaVirtual.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class GerenciarEmail
    {
        private const bool V = true;
        private readonly ILogger<GerenciarEmail> _logger;
        private SmtpClient _smtp;
        private IConfiguration _configuration;
        public GerenciarEmail(SmtpClient smtp, IConfiguration configuration, ILogger<GerenciarEmail> logger)
        {
            _smtp = smtp;
            _configuration = configuration;
            _logger = logger;
        }

        public void EnviarContatoPorEmail(Contato contato)
        {
            try
            {
#pragma warning disable CA2000 // Dispose objects before losing scope
                MailMessage message = new MailMessage()
                {
                    From = new MailAddress(_configuration.GetValue<string>("Email:UserName")),
                    Sender = new MailAddress("edinei.menezes@gmail.com", "Edinei"),
                    Subject = "LojaVirtual-ECM",
#pragma warning disable CA1305 // Specify IFormatProvider
                    Body = string.Format("<h3>Email da lojaVirtual</h3><br/> " +
                                                 "Nome: " + contato.Nome + "<br/>" +
                                                 " Email: " + contato.Email + "<br/>" +
                                                 " texto: " + contato.Texto),
#pragma warning restore CA1305 // Specify IFormatProvider
                    IsBodyHtml = true
                };
#pragma warning restore CA2000 // Dispose objects before losing scope


                _smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }
            
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Pending>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<Pending>")]
        public void EnviarSenhaParaColaboradorPorEmail(Colaborador colaborador)
        {
            string bodyMail = string.Format("<h2>Colaborador - LojaVirtual</h2>Sua senha é:<h3>{0}</h3>", colaborador.Senha);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(_configuration.GetValue<string>("Email:UserName"));
            message.To.Add(colaborador.Email);
            message.Subject = "Sua senha lojaVirtual";
            message.Body = bodyMail;
            message.IsBodyHtml = V;

            _smtp.Send(message);
        }
    }
}
