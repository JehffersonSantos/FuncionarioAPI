using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FuncionarioAPI.Migrations
{
    public partial class AdicionandorelaçãoentreDepartamentoeFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartamentoID",
                table: "Funcionarios",
                newName: "DepartamentoId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Sigla = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Departamentos_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Departamentos_DepartamentoId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Funcionarios",
                newName: "DepartamentoID");

            migrationBuilder.AlterColumn<string>(
                name: "DepartamentoID",
                table: "Funcionarios",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
