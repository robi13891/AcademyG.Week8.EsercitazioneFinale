using AcademyG.Week8.EsercitazioneFinale.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8.EsercitazioneFinale.Core.Interfaces
{
    public interface IRistoranteBusinessLayer
    {
        #region MENU

        IEnumerable<Menu> FetchMenu(Func<Menu, bool> filter = null);
        Menu GetMenuById(int id);
        ResultBL CreateMenu(Menu menu);
        ResultBL UpdateMenu(int idMenu, Piatto piatto);
        ResultBL UpdateMenu(int idMenu);

        #endregion

        #region PIATTO

        IEnumerable<Piatto> FetchPiatti(Func<Piatto, bool> filter = null);
        Piatto GetPiattoById(int id);
        ResultBL CreatePiatto(Piatto piatto);
        ResultBL UpdatePiatto(Piatto piatto);
        ResultBL DeletePiatto(int id);

        #endregion

        #region UTENTE
        #endregion
    }
}
