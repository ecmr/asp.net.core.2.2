﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using X.PagedList;

namespace LojaVirtual.Models.ViewModels
{
    public class IndexViewModel
    {
        public NewsLetterEmail newsLetter { get; set; }
        public IPagedList<Produto> lista { get; set; }
        public List<SelectListItem> ordenacao
        {
            get
            {
                return new List<SelectListItem>(){
                new SelectListItem("Alfabética", "A"),
                new SelectListItem("Menor preço", "ME"),
                new SelectListItem("Maior preço", "MA")
            };
            }
            private set { }
        }
    }
}