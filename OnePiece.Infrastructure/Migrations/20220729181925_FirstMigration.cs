using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OnePiece.Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_akumas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: false),
                    tipo = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    primeira_aparicao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    imagem_link = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    descricao = table.Column<string>(type: "character varying(20000)", maxLength: 20000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_akumas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_personagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    idade = table.Column<int>(type: "integer", nullable: false),
                    linhagem = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    altura = table.Column<string>(type: "text", nullable: false),
                    vivo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    recompensa = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    frase_marcante = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    primeira_aparicao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    descricao = table.Column<string>(type: "character varying(20000)", maxLength: 20000, nullable: false),
                    imagem_link = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    top_cinco = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    AkumaNoMiId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_personagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_personagens_tb_akumas_AkumaNoMiId",
                        column: x => x.AkumaNoMiId,
                        principalTable: "tb_akumas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_personagens_AkumaNoMiId",
                table: "tb_personagens",
                column: "AkumaNoMiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_personagens");

            migrationBuilder.DropTable(
                name: "tb_akumas");
        }
    }
}
