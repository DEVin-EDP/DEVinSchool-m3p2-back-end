using Domain.Models;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Infrastructure.Test
{
    [TestFixture]
    public class UsuarioRepositoryTeste
    {
        [Test]
        public async Task GetUsuario_DeveRetornarListaDeUsuarios()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                              .UseInMemoryDatabase(databaseName: "DevInCursoApp")
                              .Options;

            var context = new Mock<ApplicationContext>(options);
            var usuarios = new List<Usuario>
            {
                new Usuario
                {
                    Id = 1,
                    Nome = "João",
                    CPF = "12345678900",
                    Idade = 30,
                    Email = "joao@email.com",
                    Senha = "123456",
                    Foto = "foto.jpg",
                    UsuarioAtivo = true,
                    Perfil = new Perfil { Id = 1, Nome = "usuario" },
                    DataCadastro = DateTime.Now
                },
                new Usuario
                {
                    Id = 2,
                    Nome = "Maria",
                    CPF = "98765432100",
                    Idade = 25,
                    Email = "maria@email.com",
                    Senha = "654321",
                    Foto = "foto2.jpg",
                    UsuarioAtivo = true,
                    Perfil = new Perfil { Id = 2, Nome = "admin" },
                    DataCadastro = DateTime.Now
                }
            };

            var mockSet = new Mock<DbSet<Usuario>>();
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(usuarios.AsQueryable().Provider);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(usuarios.AsQueryable().Expression);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(usuarios.AsQueryable().ElementType);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(usuarios.AsQueryable().GetEnumerator());

            context.Setup(c => c.Usuario).Returns(mockSet.Object);

            var usuarioRepository = new UsuarioRepository(context.Object);

            ActionResult<dynamic> actionResult = await usuarioRepository.GetUsuario();
            List<Usuario> resultado = actionResult.Value;
            Assert.IsInstanceOf<List<Usuario>>(resultado);
        }
    }
}
