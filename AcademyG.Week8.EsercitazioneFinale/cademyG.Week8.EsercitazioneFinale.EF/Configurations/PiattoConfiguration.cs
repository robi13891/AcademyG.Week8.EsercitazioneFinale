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
    public class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Descrizione)
                .HasMaxLength(500);

            builder.Property(p => p.Tipologia)
                .IsRequired();

            builder.Property(p => p.Prezzo)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasCheckConstraint(
                "CHK_Piatto_Prezzo",
                "Prezzo > 0"
                );

            builder
                .HasOne(x => x.Menu)
                .WithMany(x => x.Piatti);

            builder.HasData(
                new Piatto
                {
                    Id = 1,
                    Nome = "Linguine Terrificanti",
                    Descrizione = "Linguine integrali con crema di zucca e crumble salato di ceci",
                    Tipologia = Tipologia.Primo,
                    Prezzo = 12,
                    MenuId = 2                    
                },
                new Piatto
                {
                    Id = 2,
                    Nome = "Cheesecake Sanguinaria",
                    Descrizione = "Cheesecake cotta al forno con culis di frutti di bosco e menta",
                    Tipologia = Tipologia.Dolce,
                    Prezzo = 6,
                    MenuId = 2
                }
                );

               
        }
    }
}
