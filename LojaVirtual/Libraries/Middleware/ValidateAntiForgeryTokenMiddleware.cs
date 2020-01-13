﻿using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Middleware
{
    public class ValidateAntiForgeryTokenMiddleware
    {
        private RequestDelegate _next;
        private IAntiforgery _antiforgery;

        public ValidateAntiForgeryTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery)
        {
            _next = next;
            _antiforgery = antiforgery;
        }

        public async Task Invoke(HttpContext context)
        {
            var Cabecalho = context.Request.Headers["x-requested-with"];
            bool Ajax = (Cabecalho == "XMLHttpRequest") ? true : false; 

            if (HttpMethods.IsPost(context.Request.Method) && !(context.Request.Form.Files.Count == 1 && Ajax))
            {
                await _antiforgery.ValidateRequestAsync(context);
            }

            await _next(context);
        }

    }
}
