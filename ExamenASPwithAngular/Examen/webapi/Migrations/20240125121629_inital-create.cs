using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class initalcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Edituri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edituri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Autori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EdituraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autori_Edituri_EdituraId",
                        column: x => x.EdituraId,
                        principalTable: "Edituri",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AutorCarte",
                columns: table => new
                {
                    AutoriId = table.Column<int>(type: "int", nullable: false),
                    CartiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorCarte", x => new { x.AutoriId, x.CartiId });
                    table.ForeignKey(
                        name: "FK_AutorCarte_Autori_AutoriId",
                        column: x => x.AutoriId,
                        principalTable: "Autori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorCarte_Carti_CartiId",
                        column: x => x.CartiId,
                        principalTable: "Carti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorCarte_CartiId",
                table: "AutorCarte",
                column: "CartiId");

            migrationBuilder.CreateIndex(
                name: "IX_Autori_EdituraId",
                table: "Autori",
                column: "EdituraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorCarte");

            migrationBuilder.DropTable(
                name: "Autori");

            migrationBuilder.DropTable(
                name: "Carti");

            migrationBuilder.DropTable(
                name: "Edituri");
        }
    }
}
