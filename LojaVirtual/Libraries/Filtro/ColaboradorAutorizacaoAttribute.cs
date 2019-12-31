using LojaVirtual.Libraries.Login;
using LojaVirtual.Models;
using LojaVirtual.Models.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace LojaVirtual.Libraries.Filtro
{
    public class ColaboradorAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        private string _tipoColaborador;
        public ColaboradorAutorizacaoAttribute(string TipoColaborador = ColaboradorTipoConstant.Comum)
        {
            _tipoColaborador = TipoColaborador;
        }

        LoginColaborador _loginColaborador;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginColaborador = (LoginColaborador)context.HttpContext.RequestServices.GetService(typeof(LoginColaborador));
            Colaborador _colaborador = _loginColaborador.GetColaborador();
            if (_colaborador == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null); //ContentResult() { Content = "Acesso negado" };
            }
            else
            {
                if (_colaborador.Tipo == ColaboradorTipoConstant.Comum && _tipoColaborador == ColaboradorTipoConstant.Gerente)
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
