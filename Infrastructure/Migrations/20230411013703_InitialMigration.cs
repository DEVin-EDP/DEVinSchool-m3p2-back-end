using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaCurso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CursoAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CursoFavoritado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoFavoritado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoFavoritado_Curso_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoFavoritado_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoSalvo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCurso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoSalvo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoSalvo_Curso_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoSalvo_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "CargaHoraria", "CategoriaCurso", "CursoAtivo", "Informacao", "Link", "Nome", "Resumo" },
                values: new object[,]
                {
                    { 1, 60, "TECNOLOGIA", true, "Curso de Java para iniciantes", "java.com", "Curso de Java", "Introdução ao Java" },
                    { 2, 12546, "ADMINISTRACAO", true, "Administração de Empresas para iniciantes", "admdeempresas.com", "Adm de Empresas", "Introdução a Administração de Empresas" },
                    { 3, 120, "MARKETING", true, "Introdução a marketing utilizando redes sociais", "marketingrs.com", "Marketing de Redes Sociais", "aprenda utilizar redes sociais para alavancar o seu negócio" },
                    { 4, 60, "DESING", true, "Técnicas de Designer gráfico.", "designergrafico.com", "Introdução ao Design Gráfico", "Aprenda técnicas essenciais para ser um Designer gráfico." }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "cpf", "data_cadastro", "email", "foto", "idade", "nome", "senha", "ativo" },
                values: new object[,]
                {
                    { 1, "11122233308", new DateTime(2023, 4, 10, 22, 37, 3, 118, DateTimeKind.Local).AddTicks(5505), "teste@gmail.com", "https://i.pinimg.com/236x/37/01/e7/3701e763f6ded4234b68d8fac1a9fa85.jpg", 30, "teste", "teste123", true },
                    { 2, "11122233308", new DateTime(2023, 4, 10, 22, 37, 3, 118, DateTimeKind.Local).AddTicks(6021), "tiago@gmail.com", "https://i.pinimg.com/236x/05/0b/72/050b721378546e519bd6e33c4ccf9630.jpg", 22, "Tiago", "tester12345678", true },
                    { 3, "11122233308", new DateTime(2023, 4, 10, 22, 37, 3, 118, DateTimeKind.Local).AddTicks(6023), "josé@gmail.com", "https://pbs.twimg.com/profile_images/1268204267749494788/az__pHAX_400x400.jpg", 55, "José", "tester12345678", true },
                    { 5, "12345278412", new DateTime(2023, 4, 10, 22, 37, 3, 118, DateTimeKind.Local).AddTicks(6025), "ana@mail.com", "https://example.com/myphoto.jpg", 32, "Ana Martha", "ana12345", true },
                    { 6, "78945612345", new DateTime(2023, 4, 10, 22, 37, 3, 118, DateTimeKind.Local).AddTicks(6027), "callas@mail.com", "https://example.com/myphoto.jpg", 30, "Maria Callas", "123asdfg", true },
                    { 7, "23456242189", new DateTime(2023, 4, 10, 22, 37, 3, 118, DateTimeKind.Local).AddTicks(6032), "rita@mail.com\"", "https://example.com/myphoto.jpg", 82, "Rita Lee", "123asdfgh", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoFavoritado_CourseId",
                table: "CursoFavoritado",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoFavoritado_UsuarioId",
                table: "CursoFavoritado",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoSalvo_CourseId",
                table: "CursoSalvo",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoSalvo_UsuarioId",
                table: "CursoSalvo",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoFavoritado");

            migrationBuilder.DropTable(
                name: "CursoSalvo");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
