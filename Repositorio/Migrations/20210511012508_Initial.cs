using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    IdCliente = table.Column<Guid>(nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", nullable: false),
                    Ativo = table.Column<bool>(type: "Bit", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "date", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartao_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    IdCliente = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(15)", nullable: false),
                    Saldo = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conta_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    IdConta = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Evento = table.Column<string>(type: "varchar(10)", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Conta_IdConta",
                        column: x => x.IdConta,
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposito",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    IdMovimentacao = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    NumeroBoleto = table.Column<string>(type: "varchar(100)", nullable: false),
                    Credenciador = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposito_Movimentacao_IdMovimentacao",
                        column: x => x.IdMovimentacao,
                        principalTable: "Movimentacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Saque",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    IdMovimentacao = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    IdentificadorCaixaEletronico = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saque_Movimentacao_IdMovimentacao",
                        column: x => x.IdMovimentacao,
                        principalTable: "Movimentacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transferencia",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    IdMovimentacao = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    IdContaDestino = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferencia_Conta_IdContaDestino",
                        column: x => x.IdContaDestino,
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transferencia_Movimentacao_IdMovimentacao",
                        column: x => x.IdMovimentacao,
                        principalTable: "Movimentacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_IdCliente",
                table: "Cartao",
                column: "IdCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conta_IdCliente",
                table: "Conta",
                column: "IdCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deposito_IdMovimentacao",
                table: "Deposito",
                column: "IdMovimentacao");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_IdConta",
                table: "Movimentacao",
                column: "IdConta");

            migrationBuilder.CreateIndex(
                name: "IX_Saque_IdMovimentacao",
                table: "Saque",
                column: "IdMovimentacao");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_IdContaDestino",
                table: "Transferencia",
                column: "IdContaDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_IdMovimentacao",
                table: "Transferencia",
                column: "IdMovimentacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agencia");

            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "Deposito");

            migrationBuilder.DropTable(
                name: "Saque");

            migrationBuilder.DropTable(
                name: "Transferencia");

            migrationBuilder.DropTable(
                name: "Movimentacao");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
