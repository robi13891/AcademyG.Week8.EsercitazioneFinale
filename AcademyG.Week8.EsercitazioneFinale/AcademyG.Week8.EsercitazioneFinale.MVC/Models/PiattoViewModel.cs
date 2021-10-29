using AcademyG.Week8.EsercitazioneFinale.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8.EsercitazioneFinale.MVC.Models
{
    public class PiattoViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Piatto")]
        public string Nome { get; set; }
        
        public string Descrizione { get; set; }

        [Required]
        public Tipologia Tipologia { get; set; }

        [Required]
        public decimal Prezzo { get; set; }

        

    }
}
