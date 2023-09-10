using LojaVirtual.Models.ProdutoAgregador;
using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.DataBase
{
    public class CommerceLojaContext: DbContext
    {
        public CommerceLojaContext(DbContextOptions<CommerceLojaContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        // public DbSet<LojaVirtual.Models.NewsletterEmail> NewsLetterEmails { get; set; }
        public DbSet<NewsletterEmail> NewsletterEmails { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Imagem> Imagems { get; set; }
    }
}
