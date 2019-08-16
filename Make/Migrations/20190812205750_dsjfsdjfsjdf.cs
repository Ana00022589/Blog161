using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Make.Migrations
{
    public partial class dsjfsdjfsjdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ComentarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DataComentario = table.Column<DateTime>(nullable: false),
                    Artista = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ComentarioId);
                });

            migrationBuilder.CreateTable(
                name: "Rimel",
                columns: table => new
                {
                    RimelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rimel", x => x.RimelId);
                });

            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    MensagemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    RimelId = table.Column<int>(nullable: false),
                    ComentarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.MensagemId);
                    table.ForeignKey(
                        name: "FK_Mensagem_Comentario_ComentarioId",
                        column: x => x.ComentarioId,
                        principalTable: "Comentario",
                        principalColumn: "ComentarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mensagem_Rimel_RimelId",
                        column: x => x.RimelId,
                        principalTable: "Rimel",
                        principalColumn: "RimelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_ComentarioId",
                table: "Mensagem",
                column: "ComentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_RimelId",
                table: "Mensagem",
                column: "RimelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mensagem");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Rimel");
        }
    }
}
