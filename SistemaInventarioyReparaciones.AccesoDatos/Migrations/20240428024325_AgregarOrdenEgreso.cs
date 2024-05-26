using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaInventarioyReparaciones.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarOrdenEgreso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdenEgreso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioAppId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroOficio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreRecibe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oficina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenEgreso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenEgreso_AspNetUsers_UsuarioAppId",
                        column: x => x.UsuarioAppId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenEgreso_UsuarioAppId",
                table: "OrdenEgreso",
                column: "UsuarioAppId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenEgreso");
        }
    }
}
