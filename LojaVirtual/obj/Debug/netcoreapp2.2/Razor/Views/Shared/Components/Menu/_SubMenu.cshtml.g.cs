#pragma checksum "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebe266c9869b389fd784f8632d7caf0b4543a876"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Menu__SubMenu), @"mvc.1.0.view", @"/Views/Shared/Components/Menu/_SubMenu.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Menu/_SubMenu.cshtml", typeof(AspNetCore.Views_Shared_Components_Menu__SubMenu))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebe266c9869b389fd784f8632d7caf0b4543a876", @"/Views/Shared/Components/Menu/_SubMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f481c602a4d8db024e6600ab0eab7c40549f1512", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Menu__SubMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml"
  
    var TodasCategorias = (List<Categoria>)ViewData["TodasCategorias"] ?? (List<Categoria>)ViewBag.TodasCategorias;
    var categoriaPai = (Categoria)ViewData["categoriaPai"] ?? ViewBag.Categoria;


    var categoriasFilho = TodasCategorias.Where(c => c.CategoriaPaiId == categoriaPai.Id).ToList();

#line default
#line hidden
#line 8 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml"
 if (categoriasFilho.Count() > 0)
{

#line default
#line hidden
            BeginContext(349, 91, true);
            WriteLiteral("    <li class=\"dropdown-submenu\">\r\n        <a class=\"dropdown-item\" tabindex=\"-1\" href=\"#\">");
            EndContext();
            BeginContext(441, 17, false);
#line 11 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml"
                                                   Write(categoriaPai.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(458, 42, true);
            WriteLiteral("</a>\r\n        <ul class=\"dropdown-menu\">\r\n");
            EndContext();
#line 13 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml"
             foreach (var subCategoria in categoriasFilho)
            {
                

#line default
#line hidden
#line 15 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml"
                 if (TodasCategorias.Where(c => c.CategoriaPaiId == subCategoria.Id).Count() > 0)
                {
                    ViewData.Remove("categoriaPai");

                    

#line default
#line hidden
            BeginContext(770, 144, false);
#line 19 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml"
               Write(await Html.PartialAsync("~/Views/Shared/Components/Menu/_SubMenu.cshtml", new ViewDataDictionary(ViewData) { { "categoriaPai", subCategoria } }));

#line default
#line hidden
            EndContext();
#line 19 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml"
                                                                                                                                                                     
                }
                else
                {

#line default
#line hidden
            BeginContext(976, 58, true);
            WriteLiteral("                    <li class=\"dropdown-item\"><a href=\"#\">");
            EndContext();
            BeginContext(1035, 17, false);
#line 23 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml"
                                                     Write(subCategoria.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1052, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 24 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml"
                }

#line default
#line hidden
#line 24 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml"
                 

            }

#line default
#line hidden
            BeginContext(1099, 26, true);
            WriteLiteral("        </ul>\r\n    </li>\r\n");
            EndContext();
#line 29 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1137, 42, true);
            WriteLiteral("    <li class=\"dropdown-item\"><a href=\"#\">");
            EndContext();
            BeginContext(1180, 17, false);
#line 32 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml"
                                     Write(categoriaPai.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1197, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 33 "C:\udemy\asp.net.core.2.2\LojaVirtual\Views\Shared\Components\Menu\_SubMenu.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591