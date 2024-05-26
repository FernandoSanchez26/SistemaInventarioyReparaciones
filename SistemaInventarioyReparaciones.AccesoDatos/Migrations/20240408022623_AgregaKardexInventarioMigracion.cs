using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaInventarioyReparaciones.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregaKardexInventarioMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventarioDetalles_Inventarios_InventarioId",
                table: "InventarioDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioDetalles_Productos_ProductoId",
                table: "InventarioDetalles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventarioDetalles",
                table: "InventarioDetalles");

            migrationBuilder.RenameTable(
                name: "InventarioDetalles",
                newName: "InventariosDetalles");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioDetalles_ProductoId",
                table: "InventariosDetalles",
                newName: "IX_InventariosDetalles_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioDetalles_InventarioId",
                table: "InventariosDetalles",
                newName: "IX_InventariosDetalles_InventarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventariosDetalles",
                table: "InventariosDetalles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "KardexInventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodegaProductoId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockAnterior = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    UsuarioAppId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KardexInventarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KardexInventarios_AspNetUsers_UsuarioAppId",
                        column: x => x.UsuarioAppId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KardexInventarios_BodegasProductos_BodegaProductoId",
                        column: x => x.BodegaProductoId,
                        principalTable: "BodegasProductos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KardexInventarios_BodegaProductoId",
                table: "KardexInventarios",
                column: "BodegaProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_KardexInventarios_UsuarioAppId",
                table: "KardexInventarios",
                column: "UsuarioAppId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventariosDetalles_Inventarios_InventarioId",
                table: "InventariosDetalles",
                column: "InventarioId",
                principalTable: "Inventarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventariosDetalles_Productos_ProductoId",
                table: "InventariosDetalles",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventariosDetalles_Inventarios_InventarioId",
                table: "InventariosDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_InventariosDetalles_Productos_ProductoId",
                table: "InventariosDetalles");

            migrationBuilder.DropTable(
                name: "KardexInventarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventariosDetalles",
                table: "InventariosDetalles");

            migrationBuilder.RenameTable(
                name: "InventariosDetalles",
                newName: "InventarioDetalles");

            migrationBuilder.RenameIndex(
                name: "IX_InventariosDetalles_ProductoId",
                table: "InventarioDetalles",
                newName: "IX_InventarioDetalles_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_InventariosDetalles_InventarioId",
                table: "InventarioDetalles",
                newName: "IX_InventarioDetalles_InventarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventarioDetalles",
                table: "InventarioDetalles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioDetalles_Inventarios_InventarioId",
                table: "InventarioDetalles",
                column: "InventarioId",
                principalTable: "Inventarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioDetalles_Productos_ProductoId",
                table: "InventarioDetalles",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id");
        }
    }
}
