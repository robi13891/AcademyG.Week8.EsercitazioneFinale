using AcademyG.Week8.EsercitazioneFinale.Core.Models;
using AcademyG.Week8.EsercitazioneFinale.EF.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8.EsercitazioneFinale.EF
{
    public class RistoranteContext : DbContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Piatto> Piatti { get; set; }

        public RistoranteContext(DbContextOptions<RistoranteContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Menu>(new MenuConfiguration());
            builder.ApplyConfiguration<Piatto>(new PiattoConfiguration());
        }
    }
}
