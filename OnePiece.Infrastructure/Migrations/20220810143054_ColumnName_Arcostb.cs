using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnePiece.Infrastructure.Migrations
{
    public partial class ColumnName_Arcostb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_arcos",
                newName: "nome");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "tb_arcos",
                type: "character varying(17)",
                maxLength: 17,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome",
                table: "tb_arcos",
                newName: "Nome");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "tb_arcos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(17)",
                oldMaxLength: 17);
        }
    }
}
