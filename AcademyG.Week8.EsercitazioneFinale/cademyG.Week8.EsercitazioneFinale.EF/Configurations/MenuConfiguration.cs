using AcademyG.Week8.EsercitazioneFinale.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8.EsercitazioneFinale.EF.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .HasMany(x => x.Piatti)
                .WithOne(x => x.Menu);


            builder.HasData(
                new Menu
                {
                    Id = 1,
                    Nome = "Menu Autunno 2021"
                },
                new Menu
                {
                    Id = 2,
                    Nome = "Menu Halloween 2021"
                }
                );
        }
    }
}
