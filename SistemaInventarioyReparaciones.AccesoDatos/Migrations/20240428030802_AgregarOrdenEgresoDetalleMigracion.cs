using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaInventarioyReparaciones.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarOrdenEgresoDetalleMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DespachoProducto_AspNetUsers_UsuarioAppId",
                table: "DespachoProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_DespachoProducto_Productos_ProductoId",
                table: "DespachoProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenEgreso_AspNetUsers_UsuarioAppId",
                table: "OrdenEgreso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdenEgreso",
                table: "OrdenEgreso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DespachoProducto",
                table: "DespachoProducto");

            migrationBuilder.RenameTable(
                name: "OrdenEgreso",
                newName: "OrdenesEgreso");

            migrationBuilder.RenameTable(
                name: "DespachoProducto",
                newName: "DespachoProductos");

            migrationBuilder.RenameIndex(
                name: "IX_OrdenEgreso_UsuarioAppId",
                table: "OrdenesEgreso",
                newName: "IX_OrdenesEgreso_UsuarioAppId");

            migrationBuilder.RenameIndex(
                name: "IX_DespachoProducto_UsuarioAppId",
                table: "DespachoProductos",
                newName: "IX_DespachoProductos_UsuarioAppId");

            migrationBuilder.RenameIndex(
                name: "IX_DespachoProducto_ProductoId",
                table: "DespachoProductos",
                newName: "IX_DespachoProductos_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdenesEgreso",
                table: "OrdenesEgreso",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DespachoProductos",
                table: "DespachoProductos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrdenesEgresoDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenEgresoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesEgresoDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenesEgresoDetalles_OrdenesEgreso_OrdenEgresoId",
                        column: x => x.OrdenEgresoId,
                        principalTable: "OrdenesEgreso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdenesEgresoDetalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesEgresoDetalles_OrdenEgresoId",
                table: "OrdenesEgresoDetalles",
                column: "OrdenEgresoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesEgresoDetalles_ProductoId",
                table: "OrdenesEgresoDetalles",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DespachoProductos_AspNetUsers_UsuarioAppId",
                table: "DespachoProductos",
                column: "UsuarioAppId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DespachoProductos_Productos_ProductoId",
                table: "DespachoProductos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesEgreso_AspNetUsers_UsuarioAppId",
                table: "OrdenesEgreso",
                column: "UsuarioAppId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DespachoProductos_AspNetUsers_UsuarioAppId",
                table: "DespachoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_DespachoProductos_Productos_ProductoId",
                table: "DespachoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesEgreso_AspNetUsers_UsuarioAppId",
                table: "OrdenesEgreso");

            migrationBuilder.DropTable(
                name: "OrdenesEgresoDetalles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdenesEgreso",
                table: "OrdenesEgreso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DespachoProductos",
                table: "DespachoProductos");

            migrationBuilder.RenameTable(
                name: "OrdenesEgreso",
                newName: "OrdenEgreso");

            migrationBuilder.RenameTable(
                name: "DespachoProductos",
                newName: "DespachoProducto");

            migrationBuilder.RenameIndex(
                name: "IX_OrdenesEgreso_UsuarioAppId",
                table: "OrdenEgreso",
                newName: "IX_OrdenEgreso_UsuarioAppId");

            migrationBuilder.RenameIndex(
                name: "IX_DespachoProductos_UsuarioAppId",
                table: "DespachoProducto",
                newName: "IX_DespachoProducto_UsuarioAppId");

            migrationBuilder.RenameIndex(
                name: "IX_DespachoProductos_ProductoId",
                table: "DespachoProducto",
                newName: "IX_DespachoProducto_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdenEgreso",
                table: "OrdenEgreso",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DespachoProducto",
                table: "DespachoProducto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DespachoProducto_AspNetUsers_UsuarioAppId",
                table: "DespachoProducto",
                column: "UsuarioAppId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DespachoProducto_Productos_ProductoId",
                table: "DespachoProducto",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenEgreso_AspNetUsers_UsuarioAppId",
                table: "OrdenEgreso",
                column: "UsuarioAppId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
