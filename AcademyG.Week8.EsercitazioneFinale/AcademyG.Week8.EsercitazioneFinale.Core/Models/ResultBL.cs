using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8.EsercitazioneFinale.Core.Models
{
    public class ResultBL
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ResultBL(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
