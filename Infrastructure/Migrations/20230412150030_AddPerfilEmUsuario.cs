using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPerfilEmUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "perfil_funcao",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "perfil_funcao" },
                values: new object[] { 2 });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "perfil_funcao" },
                values: new object[] { 1 });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "perfil_funcao" },
                values: new object[] { 1 });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "perfil_funcao" },
                values: new object[] { 1 });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "perfil_funcao" },
                values: new object[] { 1 });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "perfil_funcao" }, 
                values: new object[] { 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_perfil_funcao",
                table: "Usuario",
                column: "perfil_funcao");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_perfil_funcao",
                table: "Usuario",
                column: "perfil_funcao",
                principalTable: "Perfil",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_perfil_funcao",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_perfil_funcao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "perfil_funcao",
                table: "Usuario");
        }
    }
}
