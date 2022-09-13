using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ekle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LanguageTechs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTechs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageTechs_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LanguageTechs",
                columns: new[] { "Id", "Active", "LanguageId", "Name" },
                values: new object[] { 1, 1, 1, "Django" });

            migrationBuilder.InsertData(
                table: "LanguageTechs",
                columns: new[] { "Id", "Active", "LanguageId", "Name" },
                values: new object[] { 2, 1, 1, "Tensorflow" });

            migrationBuilder.InsertData(
                table: "LanguageTechs",
                columns: new[] { "Id", "Active", "LanguageId", "Name" },
                values: new object[] { 3, 1, 2, "Maven" });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTechs_LanguageId",
                table: "LanguageTechs",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageTechs");
        }
    }
}
