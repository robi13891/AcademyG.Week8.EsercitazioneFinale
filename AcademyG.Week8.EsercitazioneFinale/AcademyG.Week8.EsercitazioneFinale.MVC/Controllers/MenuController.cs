using AcademyG.Week8.EsercitazioneFinale.Core.Interfaces;
using AcademyG.Week8.EsercitazioneFinale.MVC.Helpers;
using AcademyG.Week8.EsercitazioneFinale.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8.EsercitazioneFinale.MVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly IRistoranteBusinessLayer ristoranteBl;

        public MenuController(IRistoranteBusinessLayer rbl) 
        {
            ristoranteBl = rbl;
        }
        public IActionResult Index()
        {
            var result = ristoranteBl.FetchMenu();
            var resultMapping = result.ToViewModel();
            
            return View(resultMapping);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id <= 0)
                return View("Error");
            var menu = ristoranteBl.GetMenuById(id);
            
            IList<PiattoViewModel> resultMapped = new List<PiattoViewModel>();

            foreach(var item in menu.Piatti)
            {
                var piattoMapped = item.ToViewModel();
                resultMapped.Add(piattoMapped);
            }
            

            return View("Detail", resultMapped);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id <= 0)
                return View("NotFound");
            var menu = ristoranteBl.GetMenuById(id);
            if (menu == null)
                return View("NotFound");
            var menuViewModel = menu.ToViewModel();
            return View("Edit", menuViewModel);
        }

        [HttpPost]
        public IActionResult Edit(MenuViewModel mvm)
        {
            if (!ModelState.IsValid)
                return View(mvm);
            if (mvm == null)
                return View("Error");
            
            var menu = mvm.ToMenu();
            var result = ristoranteBl.UpdateMenu(menu.Id);
            if (!result.Success)
                return View("Error");
            return View("Index");

        }
    }
}
