using AcademyG.Week8.EsercitazioneFinale.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8.EsercitazioneFinale.MVC.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Menù")]
        public string Nome { get; set; }

        public IList<Piatto> Piatti {get; set; } 
    }
}
