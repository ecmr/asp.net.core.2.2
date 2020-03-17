﻿using LojaVirtual.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

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

        public static List<Imagem> MoverImagensProduto(List<string> ListaCaminhoTemp, int ProdutoId)
        {
            var CaminhoFinal = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", ProdutoId.ToString());
            if (!Directory.Exists(CaminhoFinal))
            {
                Directory.CreateDirectory(CaminhoFinal);
            }

            List<Imagem> ListaFinalRetorno = new List<Imagem>();

            foreach (var caminhoTemp in ListaCaminhoTemp)
            {
                if (!string.IsNullOrEmpty(caminhoTemp))
                {
                    var nomeImagem = Path.GetFileName(caminhoTemp);

                    var CaminhoDef = Path.Combine("/uploads", ProdutoId.ToString(), nomeImagem).Replace("\\", "/");

                    if (CaminhoDef != caminhoTemp)
                    {
                        var caminhoTotalTemp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\temp", nomeImagem);
                        var caminhoTotalFinal = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", ProdutoId.ToString(), nomeImagem);

                        if (File.Exists(caminhoTotalTemp))
                        {
                            if (File.Exists(caminhoTotalFinal))
                                File.Delete(caminhoTotalFinal);

                            File.Copy(caminhoTotalTemp, caminhoTotalFinal);

                            if (File.Exists(caminhoTotalFinal))
                                File.Delete(caminhoTotalTemp);

                            ListaFinalRetorno.Add(new Imagem() { Caminho = Path.Combine("/uploads", ProdutoId.ToString(), nomeImagem).Replace("\\", "/"), ProdutoId = ProdutoId });
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        ListaFinalRetorno.Add(new Imagem() { Caminho = Path.Combine("/uploads", ProdutoId.ToString(), nomeImagem).Replace("\\", "/"), ProdutoId = ProdutoId });
                    }
                }
            }
            return ListaFinalRetorno;
        }

        public static void ExcluirImagensProduto(List<Imagem> lstImagem)
        {
            int produtoId = 0;
            foreach (var imagem in lstImagem)
            {
                ExcluirImagemProduto(imagem.Caminho);
                produtoId = imagem.ProdutoId;
            }

            var PastaProduto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", produtoId.ToString());

            if (Directory.Exists(PastaProduto))
            {
                Directory.Delete(PastaProduto);
            }
        }
    }
}