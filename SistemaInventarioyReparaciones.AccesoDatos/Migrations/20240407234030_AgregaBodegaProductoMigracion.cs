using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaInventarioyReparaciones.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregaBodegaProductoMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodegasProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodegaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodegasProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodegasProductos_Bodegas_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodegas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BodegasProductos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodegasProductos_BodegaId",
                table: "BodegasProductos",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_BodegasProductos_ProductoId",
                table: "BodegasProductos",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodegasProductos");
        }
    }
}
