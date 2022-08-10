using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OnePiece.Infrastructure.Migrations
{
    public partial class Tb_Arcos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_arcos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    imagem_link = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    volumes = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    capitulos_manga = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    ano_lancamento = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    descricao = table.Column<string>(type: "character varying(20000)", maxLength: 20000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_arcos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_arcos");
        }
    }
}
