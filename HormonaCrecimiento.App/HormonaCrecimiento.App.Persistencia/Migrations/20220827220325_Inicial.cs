using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HormonaCrecimiento.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parentesco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Familiar_Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistroRetThus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitud = table.Column<float>(type: "real", nullable: true),
                    Longitud = table.Column<float>(type: "real", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FamiliarId = table.Column<int>(type: "int", nullable: true),
                    PediatraId = table.Column<int>(type: "int", nullable: true),
                    EndocrinoId = table.Column<int>(type: "int", nullable: true),
                    HistoriaClinicaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Historias_HistoriaClinicaId",
                        column: x => x.HistoriaClinicaId,
                        principalTable: "Historias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Personas_EndocrinoId",
                        column: x => x.EndocrinoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Personas_Personas_FamiliarId",
                        column: x => x.FamiliarId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Personas_Personas_PediatraId",
                        column: x => x.PediatraId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tratamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHoraTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoriaClinicaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tratamientos_Historias_HistoriaClinicaId",
                        column: x => x.HistoriaClinicaId,
                        principalTable: "Historias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatronesCrecimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    TipoPatron = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatronesCrecimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatronesCrecimiento_Personas_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatronesCrecimiento_PacienteId",
                table: "PatronesCrecimiento",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EndocrinoId",
                table: "Personas",
                column: "EndocrinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_FamiliarId",
                table: "Personas",
                column: "FamiliarId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_HistoriaClinicaId",
                table: "Personas",
                column: "HistoriaClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PediatraId",
                table: "Personas",
                column: "PediatraId");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamientos_HistoriaClinicaId",
                table: "Tratamientos",
                column: "HistoriaClinicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatronesCrecimiento");

            migrationBuilder.DropTable(
                name: "Tratamientos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Historias");
        }
    }
}
