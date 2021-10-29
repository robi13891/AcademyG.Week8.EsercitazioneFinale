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
    public class PiattoContoller : Controller
    {
        private readonly IRistoranteBusinessLayer ristoranteBl;

        public PiattoContoller(IRistoranteBusinessLayer rbl)
        {
            ristoranteBl = rbl;
        }

        [Route("Piatto/Index")]
        public IActionResult Index()
        {
            var result = ristoranteBl.FetchPiatti();
            var resultMapping = result.ToViewModel();

            return View(resultMapping);
        }
    }
}
