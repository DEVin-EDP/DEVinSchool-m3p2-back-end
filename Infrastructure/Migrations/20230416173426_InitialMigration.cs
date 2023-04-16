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
                name: "Perfil",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.id);
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
                    data_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    perfil_funcao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil_perfil_funcao",
                        column: x => x.perfil_funcao,
                        principalTable: "Perfil",
                        principalColumn: "id",
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
                table: "Perfil",
                columns: new[] { "id", "nome" },
                values: new object[,]
                {
                    { 1, "usuario" },
                    { 2, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "carga_horaria", "categoria_curso", "curso_ativo", "informacao", "imagem_curso", "nome", "resumo" },
                values: new object[,]
                {
                    { 1, 60, 1, true, "Curso de Java para iniciantes", "https://w7.pngwing.com/pngs/961/251/png-transparent-java-runtime-environment-programming-language-programmer-computer-programming-java-text-logo-software-developer.png", "Curso de Java", "Introdução ao Java" },
                    { 2, 12546, 2, true, "Administração de Empresas para iniciantes", "https://i.pinimg.com/originals/8a/1a/5c/8a1a5c0186881d4a51783bd72b764f9f.png", "Adm de Empresas", "Introdução a Administração de Empresas" },
                    { 3, 120, 3, true, "Introdução a marketing utilizando redes sociais", "https://w7.pngwing.com/pngs/702/844/png-transparent-social-media-marketing-digital-marketing-digital-media-social-media-text-service-social-media-marketing.png", "Marketing de Redes Sociais", "aprenda utilizar redes sociais para alavancar o seu negócio" },
                    { 4, 60, 4, true, "Técnicas de Designer gráfico.", "https://e7.pngegg.com/pngimages/850/473/png-clipart-logo-graphic-design-graphics-product-design-logo-graphic-design.png", "Introdução ao Design Gráfico", "Aprenda técnicas essenciais para ser um Designer gráfico." },
                    { 5, 100, 1, true, "Técnicas de Banco de Dados.", "https://w7.pngwing.com/pngs/108/671/png-transparent-database-administrator-computer-icons-others-orange-logo-data.png", "Tecnologia em Banco de Dados", "Aprenda aprenderá como trabalhar com grande quantidade de informações e dados que entram no banco de dados de uma empresa, como por exemplo, salários, lista de clientes e fornecedores, relatórios, dentre outros. É uma atividade muito minuciosa, na qual o profissional a desenvolverá sendo incumbido de organizar tais dados, de modo a deixá-los sempre atualizados, realizando a manutenção dos mesmos." },
                    { 6, 60, 1, true, "Rede de Computadores para iniciantes", "https://e7.pngegg.com/pngimages/863/566/png-clipart-computer-network-computer-icons-local-area-network-information-technology-internet-computer-computer-network-computer.png", "Tecnologia em rede de Computadores", "O estudante aprenderá como disponibilizar várias redes e gerenciar todas elas para a empresa, como intranet, bluetooth, WI-FI, internet e LAN, além de sistemas de seguranças para não haver prejuízos." },
                    { 7, 900, 1, true, "Faculdade contendo tudo que engloba sistema de informação.", "https://w7.pngwing.com/pngs/435/773/png-transparent-information-system-sao-paulo-state-technological-college-technology-technology.png", "Sistema de Informação", "curso em que se aprende a trabalhar com redes de computadores podendo administrar, criar, garantir a segurança das redes, instalar e configurar sistemas de softwares, dentre outros aprendizados." },
                    { 8, 124, 2, true, "As atividades que este profissional realiza em seu cotidiano dependem do setor da economia.", "https://w7.pngwing.com/pngs/335/1019/png-transparent-logistics-international-trade-export-transport-others-freight-transport-service-cargo.png", "Administração de Comércio exterior.", "O profissional que atua na área de Comércio Exterior é o responsável por realizar a compra e venda de produtos e serviços entre instituições de diferentes países. É por isso que ele sempre precisa estar atento ao que acontece no mundo todo, principalmente nos assuntos econômicos, sociais e políticos do país em que se está negociando." },
                    { 9, 120, 3, true, "Quando falamos de profissionais de nível avançado, estamos nos referindo a especialistas.", "https://w7.pngwing.com/pngs/48/230/png-transparent-digital-marketing-mass-media-marketing-text-computer-logo.png", "Master em Marketing e Comunicação Digital", "tem como principal objetivo oferecer conhecimentos e habilidades para que o profissional esteja capacitado a utilizar a internet em processos de vendas empresariais, com o intuito de aumentar a competitividade da organização no mercado de trabalho." },
                    { 10, 60, 4, true, "Habilitado para criar, projetar e realizar a execução de jogos eletrônicos para diversos aparelhos, como smartphones, tablets ou computadores.", "https://w7.pngwing.com/pngs/50/329/png-transparent-video-game-development-computer-icons-video-game-developer-design.png", "Design de Games", "O profissional da área de Design de Games precisa compreender o público-alvo e as tendências do mercado que ele está inserido. Dentro do processo de produção, o Designer de Games tomará decisões com o objetivo de tornar o seu produto atraente e operante." }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "cpf", "data_cadastro", "email", "foto", "idade", "nome", "perfil_funcao", "senha", "ativo" },
                values: new object[,]
                {
                    { 1, "11122233308", new DateTime(2023, 4, 16, 18, 18, 26, 643, DateTimeKind.Local).AddTicks(467), "teste@gmail.com", "https://i.pinimg.com/236x/37/01/e7/3701e763f6ded4234b68d8fac1a9fa85.jpg", 30, "teste", 2, "teste123", true },
                    { 2, "11122233308", new DateTime(2023, 4, 16, 18, 18, 26, 643, DateTimeKind.Local).AddTicks(860), "tiago@gmail.com", "https://i.pinimg.com/236x/05/0b/72/050b721378546e519bd6e33c4ccf9630.jpg", 22, "Tiago", 1, "tester12345678", true },
                    { 3, "11122233308", new DateTime(2023, 4, 16, 18, 18, 26, 643, DateTimeKind.Local).AddTicks(863), "josé@gmail.com", "https://pbs.twimg.com/profile_images/1268204267749494788/az__pHAX_400x400.jpg", 55, "José", 1, "tester12345678", true },
                    { 5, "12345278412", new DateTime(2023, 4, 16, 18, 18, 26, 643, DateTimeKind.Local).AddTicks(865), "ana@mail.com", "https://example.com/myphoto.jpg", 32, "Ana Martha", 1, "ana12345", true },
                    { 6, "78945612345", new DateTime(2023, 4, 16, 18, 18, 26, 643, DateTimeKind.Local).AddTicks(867), "callas@mail.com", "https://example.com/myphoto.jpg", 30, "Maria Callas", 1, "123asdfg", true },
                    { 7, "23456242189", new DateTime(2023, 4, 16, 18, 18, 26, 643, DateTimeKind.Local).AddTicks(872), "rita@mail.com\"", "https://example.com/myphoto.jpg", 82, "Rita Lee", 1, "rita1234", true }
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

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_perfil_funcao",
                table: "Usuario",
                column: "perfil_funcao");
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

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
