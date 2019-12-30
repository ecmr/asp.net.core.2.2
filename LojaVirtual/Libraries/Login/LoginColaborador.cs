using LojaVirtual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Login
{
    public class LoginColaborador
    {
        private string key = "Login.Colaborador";
        private Sessao.Sessao _sessao;
        public LoginColaborador(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Colaborador colaborador)
        {
            //Serializar
            String ColaboradorJSONString = JsonConvert.SerializeObject(colaborador);
            _sessao.Cadastrar(key, ColaboradorJSONString);
        }

        public Colaborador GetColaborador()
        {
            String ColaboradorJSONString = string.Empty;
            if (_sessao.Existe(key))
            {
                ColaboradorJSONString = _sessao.Consultar(key);
            }
            return JsonConvert.DeserializeObject<Colaborador>(ColaboradorJSONString);
        }

        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
