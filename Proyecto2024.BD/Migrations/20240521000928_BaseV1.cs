using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2024.BD.Migrations
{
    /// <inheritdoc />
    public partial class BaseV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "TDocumentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Personas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Titulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TituloId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidades_Titulos_TituloId",
                        column: x => x.TituloId,
                        principalTable: "Titulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profesiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    TituloId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesiones_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profesiones_Titulos_TituloId",
                        column: x => x.TituloId,
                        principalTable: "Titulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesionId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matriculas_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matriculas_Profesiones_ProfesionId",
                        column: x => x.ProfesionId,
                        principalTable: "Profesiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "Especialidad_UQ",
                table: "Especialidades",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_TituloId",
                table: "Especialidades",
                column: "TituloId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_EspecialidadId",
                table: "Matriculas",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "Matricula_UQ",
                table: "Matriculas",
                columns: new[] { "ProfesionId", "EspecialidadId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesiones_TituloId",
                table: "Profesiones",
                column: "TituloId");

            migrationBuilder.CreateIndex(
                name: "Profesion_UQ",
                table: "Profesiones",
                columns: new[] { "PersonaId", "TituloId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Titulo_UQ",
                table: "Titulos",
                column: "Codigo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas",
                column: "TDocumentoId",
                principalTable: "TDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Profesiones");

            migrationBuilder.DropTable(
                name: "Titulos");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "TDocumentos");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Personas");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas",
                column: "TDocumentoId",
                principalTable: "TDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
