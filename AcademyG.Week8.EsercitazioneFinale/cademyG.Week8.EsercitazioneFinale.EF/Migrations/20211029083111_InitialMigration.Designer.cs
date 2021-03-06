// <auto-generated />
using AcademyG.Week8.EsercitazioneFinale.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcademyG.Week8.EsercitazioneFinale.EF.Migrations
{
    [DbContext(typeof(RistoranteContext))]
    [Migration("20211029083111_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AcademyG.Week8.EsercitazioneFinale.Core.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Menu");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Menu Autunno 2021"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Menu Halloween 2021"
                        });
                });

            modelBuilder.Entity("AcademyG.Week8.EsercitazioneFinale.Core.Models.Piatto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Tipologia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Piatti");

                    b.HasCheckConstraint("CHK_Piatto_Prezzo", "Prezzo > 0");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descrizione = "Linguine integrali con crema di zucca e crumble salato di ceci",
                            MenuId = 2,
                            Nome = "Linguine Terrificanti",
                            Prezzo = 12m,
                            Tipologia = 0
                        },
                        new
                        {
                            Id = 2,
                            Descrizione = "Cheesecake cotta al forno con culis di frutti di bosco e menta",
                            MenuId = 2,
                            Nome = "Cheesecake Sanguinaria",
                            Prezzo = 6m,
                            Tipologia = 3
                        });
                });

            modelBuilder.Entity("AcademyG.Week8.EsercitazioneFinale.Core.Models.Piatto", b =>
                {
                    b.HasOne("AcademyG.Week8.EsercitazioneFinale.Core.Models.Menu", "Menu")
                        .WithMany("Piatti")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
