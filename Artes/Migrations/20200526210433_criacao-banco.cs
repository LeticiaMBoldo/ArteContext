using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Artes.Migrations
{
    public partial class criacaobanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Estado = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoObra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoObra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Endereco = table.Column<string>(maxLength: 60, nullable: true),
                    Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Fone = table.Column<string>(maxLength: 20, nullable: true),
                    Rg = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    CidadeId = table.Column<int>(nullable: false),
                    Foto = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artista_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 1000, nullable: false),
                    TipoObraId = table.Column<int>(nullable: false),
                    ArtistaId = table.Column<int>(nullable: false),
                    InspiradaEm = table.Column<string>(maxLength: 2000, nullable: false),
                    Representa = table.Column<string>(maxLength: 2000, nullable: false),
                    FotoArte = table.Column<string>(maxLength: 500, nullable: false),
                    DataInscricao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obra_Artista_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obra_TipoObra_TipoObraId",
                        column: x => x.TipoObraId,
                        principalTable: "TipoObra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cidade",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[,]
                {
                    { 1, "SP", "Barra Bonita" },
                    { 2, "SP", "Igaraçu do Tietê" },
                    { 3, "SP", "Bauru" },
                    { 4, "SP", "Macatuba" },
                    { 5, "SP", "Pederneiras" },
                    { 6, "SP", "Lençois Paulista" }
                });

            migrationBuilder.InsertData(
                table: "TipoObra",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Fotografia" },
                    { 2, "Artes Plásticas" },
                    { 3, "Escultura" },
                    { 4, "Pintura" },
                    { 5, "Modelagem 3D" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artista_CidadeId",
                table: "Artista",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Obra_ArtistaId",
                table: "Obra",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obra_TipoObraId",
                table: "Obra",
                column: "TipoObraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obra");

            migrationBuilder.DropTable(
                name: "Artista");

            migrationBuilder.DropTable(
                name: "TipoObra");

            migrationBuilder.DropTable(
                name: "Cidade");
        }
    }
}
