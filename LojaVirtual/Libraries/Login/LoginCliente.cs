using LojaVirtual.Models;
using Newtonsoft.Json;
using System;

namespace LojaVirtual.Libraries.Login
{
    public class LoginCliente
    {
        private string key = "Login.Cliente";
        private Sessao.Sessao _sessao;
        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Cliente cliente)
        {
            //Serializar
            String ClienteJSONString = JsonConvert.SerializeObject(cliente);
            _sessao.Cadastrar(key, ClienteJSONString);
        }

        public Cliente GetCliente()
        {
            String ClienteJSONString = string.Empty;
            if (_sessao.Existe(key)) { 
                ClienteJSONString = _sessao.Consultar(key);
            }
            return JsonConvert.DeserializeObject<Cliente>(ClienteJSONString);
        }

        public void Logout()
        {
            _sessao.RemoverTodos();
        }

    }
}
