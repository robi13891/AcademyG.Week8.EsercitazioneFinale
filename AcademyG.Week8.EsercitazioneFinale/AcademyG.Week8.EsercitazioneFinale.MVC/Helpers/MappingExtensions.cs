using AcademyG.Week8.EsercitazioneFinale.Core.Models;
using AcademyG.Week8.EsercitazioneFinale.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8.EsercitazioneFinale.MVC.Helpers
{
    public static class MappingExtensions
    {
        public static MenuViewModel ToViewModel(this Menu menu)
        {
            return new MenuViewModel
            {
                Id = menu.Id,
                Nome = menu.Nome,
                Piatti = menu.Piatti
            };
        }

        public static IEnumerable<MenuViewModel> ToViewModel
            (this IEnumerable<Menu> menu)
        {
            return menu.Select(m => m.ToViewModel());
        }

        public static Menu ToMenu(this MenuViewModel menuViewModel)
        {
            return new Menu
            {
                Id = menuViewModel.Id,
                Nome = menuViewModel.Nome,
                Piatti = menuViewModel.Piatti

            };
        }

        public static IEnumerable<SelectListItem> FromEnumToSelectList<T>() where T : struct
        {
            return (Enum.GetValues(typeof(T))).Cast<T>().Select(
                    x => new SelectListItem() { Text = x.ToString(), Value = x.ToString() }).ToList();
        }



        public static PiattoViewModel ToViewModel(this Piatto piatto)
        {
            return new PiattoViewModel
            {
                Id = piatto.Id,
                Nome = piatto.Nome,
                Descrizione = piatto.Descrizione,
                Tipologia = piatto.Tipologia,
                Prezzo = piatto.Prezzo
            };
        }

        public static IEnumerable<PiattoViewModel> ToViewModel
            (this IEnumerable<Piatto> piatto)
        {
            return piatto.Select(p => p.ToViewModel());
        }
    }
}
