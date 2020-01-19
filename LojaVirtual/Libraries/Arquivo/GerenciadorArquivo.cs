using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Arquivo
{
    /// <summary>
    /// 
    /// </summary>
    public class GerenciadorArquivo
    {
        public static string CadastrarImagemProduto(IFormFile file)
        {
            //TODO - Armazenar imagem em uma pasta
            var NomeImagem = Path.GetFileName(file.FileName);
            var Caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/temp", NomeImagem);

            using (var stream = new FileStream(Caminho, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Path.Combine("/uploads/temp/", NomeImagem).Replace("\\", "/");
        }

        public static bool ExcluirImagemProduto(string caminho)
        {
            if (!string.IsNullOrEmpty(caminho))
            { 
                string Caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", caminho.TrimStart('/'));

                if (File.Exists(Caminho))
                {
                    File.Delete(Caminho);
                    return true;
                }
            }

            return false;
        }
    }
}
