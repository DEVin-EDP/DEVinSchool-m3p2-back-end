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
                name: "CategoriaCurso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaCurso", x => x.Id);
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
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    informacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carga_horaria = table.Column<int>(type: "int", nullable: false),
                    imagem_curso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    curso_ativo = table.Column<bool>(type: "bit", nullable: false),
                    categoria_curso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curso_CategoriaCurso_categoria_curso",
                        column: x => x.categoria_curso,
                        principalTable: "CategoriaCurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoSalvo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_curso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    data_curso_salvo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoSalvo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoSalvo_Curso_CursoId",
                        column: x => x.CursoId,
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
                table: "CategoriaCurso",
                columns: new[] { "Id", "titulo" },
                values: new object[,]
                {
                    { 1, "Tecnologia" },
                    { 2, "Administração" },
                    { 3, "Marketing" },
                    { 4, "Design" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "cpf", "data_cadastro", "email", "foto", "idade", "nome", "senha", "ativo" },
                values: new object[,]
                {
                    { 1, "11122233308", new DateTime(2023, 4, 12, 1, 11, 54, 604, DateTimeKind.Local).AddTicks(7300), "teste@gmail.com", "https://i.pinimg.com/236x/37/01/e7/3701e763f6ded4234b68d8fac1a9fa85.jpg", 30, "teste", "teste123", true },
                    { 2, "11122233308", new DateTime(2023, 4, 12, 1, 11, 54, 604, DateTimeKind.Local).AddTicks(7698), "tiago@gmail.com", "https://i.pinimg.com/236x/05/0b/72/050b721378546e519bd6e33c4ccf9630.jpg", 22, "Tiago", "tester12345678", true },
                    { 3, "11122233308", new DateTime(2023, 4, 12, 1, 11, 54, 604, DateTimeKind.Local).AddTicks(7700), "josé@gmail.com", "https://pbs.twimg.com/profile_images/1268204267749494788/az__pHAX_400x400.jpg", 55, "José", "tester12345678", true },
                    { 5, "12345278412", new DateTime(2023, 4, 12, 1, 11, 54, 604, DateTimeKind.Local).AddTicks(7702), "ana@mail.com", "https://example.com/myphoto.jpg", 32, "Ana Martha", "ana12345", true },
                    { 6, "78945612345", new DateTime(2023, 4, 12, 1, 11, 54, 604, DateTimeKind.Local).AddTicks(7704), "callas@mail.com", "https://example.com/myphoto.jpg", 30, "Maria Callas", "123asdfg", true },
                    { 7, "23456242189", new DateTime(2023, 4, 12, 1, 11, 54, 604, DateTimeKind.Local).AddTicks(7716), "rita@mail.com\"", "https://example.com/myphoto.jpg", 82, "Rita Lee", "123asdfgh", true }
                });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "carga_horaria", "categoria_curso", "curso_ativo", "informacao", "imagem_curso", "nome", "resumo" },
                values: new object[,]
                {
                    { 1, 60, 1, true, "Curso de Java para iniciantes", "java.com", "Curso de Java", "Introdução ao Java" },
                    { 2, 12546, 2, true, "Administração de Empresas para iniciantes", "admdeempresas.com", "Adm de Empresas", "Introdução a Administração de Empresas" },
                    { 3, 120, 3, true, "Introdução a marketing utilizando redes sociais", "marketingrs.com", "Marketing de Redes Sociais", "aprenda utilizar redes sociais para alavancar o seu negócio" },
                    { 4, 60, 4, true, "Técnicas de Designer gráfico.", "designergrafico.com", "Introdução ao Design Gráfico", "Aprenda técnicas essenciais para ser um Designer gráfico." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curso_categoria_curso",
                table: "Curso",
                column: "categoria_curso");

            migrationBuilder.CreateIndex(
                name: "IX_CursoSalvo_CursoId",
                table: "CursoSalvo",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoSalvo_UsuarioId",
                table: "CursoSalvo",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoSalvo");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "CategoriaCurso");
        }
    }
}
