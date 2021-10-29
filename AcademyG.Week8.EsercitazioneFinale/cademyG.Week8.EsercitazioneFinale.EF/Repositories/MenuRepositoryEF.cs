using AcademyG.Week8.EsercitazioneFinale.Core.Interfaces;
using AcademyG.Week8.EsercitazioneFinale.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8.EsercitazioneFinale.EF.Repositories
{
    public class MenuRepositoryEF : IMenuRepository
    {
        private readonly RistoranteContext ctx;

        public MenuRepositoryEF(RistoranteContext ctx)
        {
            this.ctx = ctx;
        }

        public bool AddItem(Menu item)
        {
            if (item == null)
                return false;
            ctx.Menu.Add(item);
            ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Menu> Fetch(Func<Menu, bool> filter = null)
        {
            if (filter != null)
                return ctx.Menu.Where(filter);
            return ctx.Menu;
        }

        public Menu GetById(int id)
        {
            if (id <= 0)
                return null;
            return ctx.Menu.Include(x => x.Piatti).FirstOrDefault(x => x.Id == id);
        }

        public bool UpdateItem(Menu item)
        {
            if (item == null)
                return false;
            ctx.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }
    }
}
