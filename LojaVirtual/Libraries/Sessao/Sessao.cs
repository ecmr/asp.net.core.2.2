using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Sessao
{
    public class Sessao
    {
        IHttpContextAccessor _contex;

        public Sessao(IHttpContextAccessor contex)
        {
            _contex = contex;
        }
        //CRUD

        public void Cadastrar(string key, string valor)
        {
            _contex.HttpContext.Session.SetString(key, valor);
        }

        public void Atualiar(string key, string valor)
        {
            if (Existe(key))
            {
                _contex.HttpContext.Session.Remove(key);
            }
            _contex.HttpContext.Session.SetString(key, valor);
        }

        public void Remover(string key)
        {
            _contex.HttpContext.Session.Remove(key);
        }

        public string Consultar(string key)
        {
            return _contex.HttpContext.Session.GetString(key);
        }

        public bool Existe(string key)
        {
            return _contex.HttpContext.Session.GetString(key) != null;
        }

        public void RemoverTodos()
        {
            _contex.HttpContext.Session.Clear();
        }
    }

}
