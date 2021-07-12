using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IMAGEM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DARACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    TELEFONE = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    DARACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CARRINHO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VALORTOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DARACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARRINHO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CARRINHO_USUARIO_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COMPRA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VALORTOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPRA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COMPRA_USUARIO_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CARRINHOPRODUTO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDPRODUTO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDCARRINHO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    VALORTOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarrinhoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DARACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARRINHOPRODUTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CARRINHOPRODUTO_CARRINHO_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "CARRINHO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CARRINHOPRODUTO_CARRINHO_IDCARRINHO",
                        column: x => x.IDCARRINHO,
                        principalTable: "CARRINHO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CARRINHOPRODUTO_PRODUTO_IDPRODUTO",
                        column: x => x.IDPRODUTO,
                        principalTable: "PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COMPRAPRODUTO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDPRODUTO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDCOMPRA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    VALORTOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPRAPRODUTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COMPRAPRODUTO_COMPRA_CompraId",
                        column: x => x.CompraId,
                        principalTable: "COMPRA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COMPRAPRODUTO_COMPRA_IDCOMPRA",
                        column: x => x.IDCOMPRA,
                        principalTable: "COMPRA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMPRAPRODUTO_PRODUTO_IDPRODUTO",
                        column: x => x.IDPRODUTO,
                        principalTable: "PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CARRINHO_IDUSUARIO",
                table: "CARRINHO",
                column: "IDUSUARIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CARRINHOPRODUTO_CarrinhoId",
                table: "CARRINHOPRODUTO",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_CARRINHOPRODUTO_IDCARRINHO",
                table: "CARRINHOPRODUTO",
                column: "IDCARRINHO");

            migrationBuilder.CreateIndex(
                name: "IX_CARRINHOPRODUTO_IDPRODUTO",
                table: "CARRINHOPRODUTO",
                column: "IDPRODUTO");

            migrationBuilder.CreateIndex(
                name: "IX_COMPRA_IDUSUARIO",
                table: "COMPRA",
                column: "IDUSUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_COMPRAPRODUTO_CompraId",
                table: "COMPRAPRODUTO",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_COMPRAPRODUTO_IDCOMPRA",
                table: "COMPRAPRODUTO",
                column: "IDCOMPRA");

            migrationBuilder.CreateIndex(
                name: "IX_COMPRAPRODUTO_IDPRODUTO",
                table: "COMPRAPRODUTO",
                column: "IDPRODUTO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CARRINHOPRODUTO");

            migrationBuilder.DropTable(
                name: "COMPRAPRODUTO");

            migrationBuilder.DropTable(
                name: "CARRINHO");

            migrationBuilder.DropTable(
                name: "COMPRA");

            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
