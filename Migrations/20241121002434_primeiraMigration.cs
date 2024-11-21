using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Migrations
{
    /// <inheritdoc />
    public partial class primeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContasBancaria",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Agencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Conta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Titular = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasBancaria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamentos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    FormaPagamentoId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ContaBancariaId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Situacao = table.Column<bool>(type: "bit", nullable: false),
                    Parcela = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Despesas_ContasBancaria_ContaBancariaId",
                        column: x => x.ContaBancariaId,
                        principalTable: "ContasBancaria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Despesas_FormaPagamentos_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CategoriaId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    FormaPagamentoId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ContaBancariaId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DataRecebimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receitas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Receitas_ContasBancaria_ContaBancariaId",
                        column: x => x.ContaBancariaId,
                        principalTable: "ContasBancaria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Receitas_FormaPagamentos_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_CategoriaId",
                table: "Despesas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_ContaBancariaId",
                table: "Despesas",
                column: "ContaBancariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_FormaPagamentoId",
                table: "Despesas",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_CategoriaId",
                table: "Receitas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_ContaBancariaId",
                table: "Receitas",
                column: "ContaBancariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_FormaPagamentoId",
                table: "Receitas",
                column: "FormaPagamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "ContasBancaria");

            migrationBuilder.DropTable(
                name: "FormaPagamentos");
        }
    }
}
