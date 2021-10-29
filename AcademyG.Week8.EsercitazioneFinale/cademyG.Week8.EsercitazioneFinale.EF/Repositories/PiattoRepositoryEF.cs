using AcademyG.Week8.EsercitazioneFinale.Core.Interfaces;
using AcademyG.Week8.EsercitazioneFinale.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8.EsercitazioneFinale.EF.Repositories
{
    public class PiattoRepositoryEF : IPiattoRepository
    {
        private readonly RistoranteContext ctx;

        public PiattoRepositoryEF(RistoranteContext ctx)
        {
            this.ctx = ctx;
        }
        public bool AddItem(Piatto item)
        {
            if (item == null)
                return false;
            ctx.Piatti.Add(item);
            ctx.SaveChanges();
            return true;
        }

        public bool DeletePiatto(int id)
        {
            if (id <= 0)
                return false;
            var result = ctx.Piatti.Find(id);
            if (result == null)
                return false;
            ctx.Piatti.Remove(result);            
            ctx.SaveChanges();
            return true;

        }

        public IEnumerable<Piatto> Fetch(Func<Piatto, bool> filter = null)
        {
            if (filter != null)
                return ctx.Piatti.Where(filter);
            return ctx.Piatti;
        }

        public Piatto GetById(int id)
        {
            if (id <= 0)
                return null;
            return ctx.Piatti.Find(id);
        }

        public bool UpdateItem(Piatto item)
        {
            if (item == null)
                return false;
            ctx.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            return true;

        }
    }
}
