using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Component
{
    public class MenuViewComponent : ViewComponent
    {
        private ICategoriaRepository _categoriaRepository;

        public MenuViewComponent(ICategoriaRepository CategoriaRepository)
        {
            _categoriaRepository = CategoriaRepository; 
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ListaCategoria = _categoriaRepository.ObterTodasCategorias().ToList();
            return View(ListaCategoria);
        }
    }
}
