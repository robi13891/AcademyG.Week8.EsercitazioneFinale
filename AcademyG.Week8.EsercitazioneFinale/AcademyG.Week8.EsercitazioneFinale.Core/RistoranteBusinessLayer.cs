using AcademyG.Week8.EsercitazioneFinale.Core.Interfaces;
using AcademyG.Week8.EsercitazioneFinale.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8.EsercitazioneFinale.Core
{
    public class RistoranteBusinessLayer : IRistoranteBusinessLayer
    {
        private readonly IMenuRepository menuRepo;
        private readonly IPiattoRepository piattoRepo;

        public RistoranteBusinessLayer(IMenuRepository menuRepo, IPiattoRepository piattoRepo)
        {
            this.menuRepo = menuRepo;
            this.piattoRepo = piattoRepo;
        }

        #region MENU
        public ResultBL CreateMenu(Menu menu)
        {
            if (menu == null)
                return new ResultBL(false, "Invalid entry");
            var result = menuRepo.AddItem(menu);
            return new ResultBL(result, result ? "Added" : "Something went wrong");
        }

        public Menu GetMenuById(int id)
        {
            if (id <= 0)
                return null;
            return menuRepo.GetById(id);
        }

        public ResultBL UpdateMenu(int idMenu)
        {
            if(idMenu<=0)
                return new ResultBL(false, "Invalid entry");
            var result = menuRepo.GetById(idMenu);
            if (result == null)
                return new ResultBL(false, "Something went wrong");
            return new ResultBL(true, "Updated");
        }

        //elimina piatto da menu
        public ResultBL UpdateMenu(int idMenu, Piatto piatto)
        {
            if (idMenu <= 0 || piatto == null)
                return new ResultBL(false, "At least one entry is invalid");
            var result = menuRepo.GetById(idMenu);
            if (result == null)
                return new ResultBL(false, "Something went wrong");
            result.Piatti.Remove(piatto);
            return new ResultBL(true, "Updated");            

        }

        public IEnumerable<Menu> FetchMenu(Func<Menu, bool> filter = null)
        {
            return menuRepo.Fetch(filter);
        }

        #endregion

        #region PIATTO
        public IEnumerable<Piatto> FetchPiatti(Func<Piatto, bool> filter = null)
        {
            return piattoRepo.Fetch(filter);
        }

        public ResultBL CreatePiatto(Piatto piatto)
        {
            if (piatto == null)
                return new ResultBL(false, "Invalid entry");
            var result = piattoRepo.AddItem(piatto);
            return new ResultBL(result, result ? "Added" : "Something went wrong");
        }

        public ResultBL DeletePiatto(int id)
        {
            if (id <= 0)
                return new ResultBL(false, "Invalid id");
            var result = piattoRepo.DeletePiatto(id);
            return new ResultBL(result, result ? "Deleted" : "Something went wrong");
        }

        public Piatto GetPiattoById(int id)
        {
            if (id <= 0)
                return null;
            return piattoRepo.GetById(id);
        }

        public ResultBL UpdatePiatto(Piatto piatto)
        {
            if (piatto == null)
                return new ResultBL(false, "Invalid entry");
            var result = piattoRepo.UpdateItem(piatto);
            return new ResultBL(result, result ? "Updated" : "Something went wrong");
        }

        #endregion
    }
}
