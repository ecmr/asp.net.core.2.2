using LojaVirtual.DataBase;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {
        private LojaVirtualContext _banco;
        public NewsletterRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }
        public void Cadastrar(NewsLetterEmail newsletter)
        {
            _banco.NewsLetterEmails.Add(newsletter);
            _banco.SaveChanges();
        }

        public IEnumerable<NewsLetterEmail> ObterTodasNewsletter()
        {
            return _banco.NewsLetterEmails.ToList();
        }
    }
}
