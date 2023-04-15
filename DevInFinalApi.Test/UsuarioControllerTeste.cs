using DevInFinalApi.Controllers;
using Domain.Models;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DevInFinalApi.Test
{
    public class UsuarioControllerTeste
    {
        [Test]
        public async Task GetUsuario_RetornaOkResult()
        {
            // Arrange
            var mockUsuarioService = new Mock<IUsuarioService>();
            var controller = new UsuarioController(mockUsuarioService.Object);
            var usuario = new Usuario
            {
                Nome = "teste",
                CPF = "11122233308",
                Idade = 30,
                Email = "teste@gmail.com",
                Senha = "senha123",
                Foto = "foto.png",
                UsuarioAtivo = true,
                DataCadastro = DateTime.Now,
                PerfilId = 2,
                Perfil = new Perfil { Nome = "admin" }
            };
            var usuarios = new List<Usuario> { usuario };
            mockUsuarioService.Setup(service => service.GetUsuario()).ReturnsAsync(usuarios);

            // Act
            var result = await controller.GetUsuario();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }
    }
}
