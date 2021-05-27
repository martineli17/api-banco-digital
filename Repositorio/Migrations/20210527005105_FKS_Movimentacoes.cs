using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class FKS_Movimentacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Cliente_IdCliente",
                table: "Conta");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacao_Conta_IdConta",
                table: "Movimentacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Cliente_IdCliente",
                table: "Conta",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacao_Conta_IdConta",
                table: "Movimentacao",
                column: "IdConta",
                principalTable: "Conta",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Cliente_IdCliente",
                table: "Conta");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacao_Conta_IdConta",
                table: "Movimentacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Cliente_IdCliente",
                table: "Conta",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacao_Conta_IdConta",
                table: "Movimentacao",
                column: "IdConta",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
