#pragma checksum "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "851c242ac7ad338459be9e492bd0ce5106f83e30"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Menu_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Menu/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Menu/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Menu_Default))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 3 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\_ViewImports.cshtml"
using LojaVirtual.Models;

#line default
#line hidden
#line 4 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#line 5 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"851c242ac7ad338459be9e492bd0ce5106f83e30", @"/Views/Shared/Components/Menu/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f481c602a4d8db024e6600ab0eab7c40549f1512", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Menu_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Categoria>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline my-2 my-lg-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\Default.cshtml"
  
    var pesquisa = Context.Request.Query["pesquisa"];

#line default
#line hidden
            BeginContext(86, 543, true);
            WriteLiteral(@"

<nav class=""navbar navbar-expand-lg navbar-dark fixed-top bg-dark"">
    <a class=""navbar-brand"" href=""/""> LojaVirtual</a>
    <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navbarSupportedContent""
            aria-controls=""navbarSupportedContent"" aria-expanded=""false"" aria-label=""Toggle navigation"">
        <span class=""navbar-toggler-icon""></span>
    </button>

    <div class=""collapse navbar-collapse"" id=""navbarSupportedContent"">

        <ul class=""navbar-nav mr-auto"">
            <li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 629, "\"", 794, 2);
            WriteAttributeValue("", 637, "nav-item", 637, 8, true);
#line 17 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue(" ", 645, (ViewContext.RouteData.Values["controller"].ToString() == "Home" && ViewContext.RouteData.Values["action"].ToString() == "Index") ? "active" : "", 646, 148, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(795, 144, true);
            WriteLiteral(">\r\n                <a class=\"nav-link\" href=\"/\"><i class=\"fas fa-home\"></i> Home <span class=\"sr-only\">(current)</span></a>\r\n            </li>\r\n");
            EndContext();
#line 20 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\Default.cshtml"
               var TodasCategorias = Model.ToList();

#line default
#line hidden
            BeginContext(994, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 22 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\Default.cshtml"
             if (TodasCategorias != null && TodasCategorias.Count > 0)
            {


#line default
#line hidden
            BeginContext(1085, 62, true);
            WriteLiteral("                <div class=\"dropdown\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1147, "\"", 1333, 3);
            WriteAttributeValue("", 1155, "nav-link", 1155, 8, true);
            WriteAttributeValue(" ", 1163, "dropdown-toggle", 1164, 16, true);
#line 26 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("  ", 1179, (ViewContext.RouteData.Values["controller"].ToString() == "Home" && ViewContext.RouteData.Values["action"].ToString() == "Categoria") ? "active" : "", 1181, 152, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1334, 355, true);
            WriteLiteral(@"
                       href=""#"" id=""navbarDropdown"" role=""button"" data-toggle=""dropdown""
                       aria-haspopup=""true"" aria-expanded=""false"">
                        <i class=""fas fa-list-ul"">Categorias</i>
                    </a>
                    <ul class=""dropdown-menu multi-level"" role=""menu"" aria-labelledby=""dropdownMenu"">
");
            EndContext();
#line 32 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\Default.cshtml"
                           var categoriasPrincipais = TodasCategorias.Where(c => c.CategoriaPaiId == null).ToList();
                            ViewData["TodasCategorias"] = TodasCategorias;
                            ViewBag.TodasCategorias = TodasCategorias;
                        

#line default
#line hidden
            BeginContext(1982, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 38 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\Default.cshtml"
                         foreach (var categoria in categoriasPrincipais)
                        {
                            ViewBag.Categoria = categoria;
                            

#line default
#line hidden
            BeginContext(2176, 141, false);
#line 41 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\Default.cshtml"
                       Write(await Html.PartialAsync("~/Views/Shared/Components/Menu/_SubMenu.cshtml", new ViewDataDictionary(ViewData) { { "categoriaPai", categoria } }));

#line default
#line hidden
            EndContext();
#line 41 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\Default.cshtml"
                                                                                                                                                                          
                        }

#line default
#line hidden
            BeginContext(2346, 51, true);
            WriteLiteral("                    </ul>\r\n                </div>\r\n");
            EndContext();
#line 45 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\Default.cshtml"

            }

#line default
#line hidden
            BeginContext(2414, 11, true);
            WriteLiteral("        <li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 2425, "\"", 2592, 2);
            WriteAttributeValue("", 2433, "nav-item", 2433, 8, true);
#line 47 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue(" ", 2441, (ViewContext.RouteData.Values["controller"].ToString() == "Home" && ViewContext.RouteData.Values["action"].ToString() == "Contato") ? "active" : "", 2442, 150, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2593, 144, true);
            WriteLiteral(">\r\n            <a class=\"nav-link\" href=\"/Home/Contato\"><i class=\"far fa-address-book\"></i> Contato </a>\r\n        </li>\r\n        </ul>\r\n        ");
            EndContext();
            BeginContext(2737, 513, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "851c242ac7ad338459be9e492bd0ce5106f83e3010169", async() => {
                BeginContext(2789, 79, true);
                WriteLiteral("\r\n            <input class=\"form-control mr-sm-2\" type=\"search\" name=\"pesquisa\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2868, "\"", 2885, 1);
#line 52 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 2876, pesquisa, 2876, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2886, 357, true);
                WriteLiteral(@" placeholder=""palavra"" aria-label=""Search"">
            <button class=""btn btn-outline-success my-2 my-sm-0"" type=""submit"">Pesquisa</button>
            <a class=""nav-link"" href=""/Home/Login""><i class=""fas fa-user-alt""></i> Login</a>
            <a class=""nav-link"" href=""/Home/CarrinhoCompras""><i class=""fas fa-shopping-cart""></i> Carrinho</a>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3250, 22, true);
            WriteLiteral("\r\n    </div>\r\n</nav>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Categoria>> Html { get; private set; }
    }
}
#pragma warning restore 1591