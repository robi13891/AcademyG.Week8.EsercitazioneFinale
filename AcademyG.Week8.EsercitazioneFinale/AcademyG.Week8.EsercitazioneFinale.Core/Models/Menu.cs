using System;
using System.Collections.Generic;

namespace AcademyG.Week8.EsercitazioneFinale.Core.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<Piatto> Piatti { get; set; }
    }
}
