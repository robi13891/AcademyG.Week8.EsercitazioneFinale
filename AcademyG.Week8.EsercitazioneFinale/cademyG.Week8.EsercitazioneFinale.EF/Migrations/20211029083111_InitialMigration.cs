using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademyG.Week8.EsercitazioneFinale.EF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Piatti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descrizione = table.Column<string>(maxLength: 500, nullable: true),
                    Tipologia = table.Column<int>(nullable: false),
                    Prezzo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piatti", x => x.Id);
                    table.CheckConstraint("CHK_Piatto_Prezzo", "Prezzo > 0");
                    table.ForeignKey(
                        name: "FK_Piatti_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Menu Autunno 2021" });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Menu Halloween 2021" });

            migrationBuilder.InsertData(
                table: "Piatti",
                columns: new[] { "Id", "Descrizione", "MenuId", "Nome", "Prezzo", "Tipologia" },
                values: new object[] { 1, "Linguine integrali con crema di zucca e crumble salato di ceci", 2, "Linguine Terrificanti", 12m, 0 });

            migrationBuilder.InsertData(
                table: "Piatti",
                columns: new[] { "Id", "Descrizione", "MenuId", "Nome", "Prezzo", "Tipologia" },
                values: new object[] { 2, "Cheesecake cotta al forno con culis di frutti di bosco e menta", 2, "Cheesecake Sanguinaria", 6m, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Piatti_MenuId",
                table: "Piatti",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piatti");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
