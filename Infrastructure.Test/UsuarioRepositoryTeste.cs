using Microsoft.EntityFrameworkCore;
using Moq;
using Domain.Models;
using Infrastructure.Repository;
using Infrastructure.Service;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore.InMemory;
using Domain.DTOs;

namespace Infrastructure.Test
{
    internal class UsuarioRepositoryTeste
    {
        private ApplicationContext dbContext;
        private UsuarioRepository _usuarioRepository;
        private List<Usuario> _usuarios;

        [TearDown]
        public void Cleanup()
        {
            dbContext.Database.EnsureDeleted();
        }

        [SetUp]
        public void Setup()
        {
            _usuarios = new List<Usuario>
            {
                new Usuario
                {
                    Id = 85,
                    Nome= "teste",
                    Email = "teste@gmail.com",
                    Idade = 30,
                    Senha = "teste123",
                    CPF = "33322233308",
                    DataCadastro = DateTime.Now,
                    Foto = "https://i.pinimg.com/236x/37/01/e7/3701e763f6ded4234b68d8fac1a9fa85.jpg",
                    UsuarioAtivo = true,
                    PerfilId = 2,
                    Perfil = new Perfil{Nome = "testedasilva"}
                },
                new Usuario
                {
                    Id = 77,
                    Nome= "Tiago",
                    Email = "tiago@gmail.com",
                    Idade = 22,
                    Senha = "tester12345678",
                    CPF = "11122233308",
                    DataCadastro = DateTime.Now,
                    Foto = "https://i.pinimg.com/236x/05/0b/72/050b721378546e519bd6e33c4ccf9630.jpg",
                    UsuarioAtivo = true,
                    PerfilId = 1,
                    Perfil = new Perfil{Nome = "tiagodasilva"}
                },
            };
            var options = new DbContextOptionsBuilder<ApplicationContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

            dbContext = new ApplicationContext(options);
            dbContext.Usuario.AddRange(_usuarios);
            dbContext.SaveChanges();

        }

        [Test]
        async public Task TestGetUsuario()
        {
            var _usuarioRepository = new UsuarioRepository(dbContext);
            var resultado = await _usuarioRepository.GetUsuario();

            var users = resultado.Value as List<Usuario>;

            Assert.True(users.Any(x => x.Nome == "teste"));
            Assert.True(users.Any(x => x.Perfil.Nome == "tiagodasilva"));
        }
        [Test]
        async public Task TestGetUsuarioById()
        {
            var _usuarioRepository = new UsuarioRepository(dbContext);
            var resultado = await _usuarioRepository.GetUsuario(77);

            var user = resultado.Value as UsuarioResponse;

            Assert.True(user.CPF == "11122233308");

        }
        [Test]
        async public Task TestPutUsuarioByRequest()
        {
            var _usuarioRepository = new UsuarioRepository(dbContext);
            var resultado = await _usuarioRepository.GetUsuario(77);
            var user = resultado.Value as UsuarioResponse;

            await _usuarioRepository.PutUsuario(77, new UsuarioPutRequest
            {
                Nome = user.Nome + " Sauro",
                Idade = user.Idade,
                Senha = user.Senha
            });

            resultado = await _usuarioRepository.GetUsuario(77);
            user = resultado.Value as UsuarioResponse;

            Assert.True(user.Nome == "Tiago Sauro");

        }
        // [Test]
        async public Task TestPostUsuario()
        {
            var _usuarioRepository = new UsuarioRepository(dbContext);
            await _usuarioRepository.PostUsuario(
           new UsuarioRequest
           {
               Nome = "Helio",
               Idade = 26,
               Cpf = "01965187258",
               Email = "helio@gmail.com",
               Senha = "tester12345678",
           });

            var resultado = await _usuarioRepository.GetUsuario();
            var user = resultado.Value as List<Usuario>;

            Assert.True(user.Any(x => x.Nome == "Helio"));
        }
        [Test]
        async public Task TestDeleteUsuario()
        {
            var _usuarioRepository = new UsuarioRepository(dbContext);
            await _usuarioRepository.DeleteUsuario(85);

            var resultado = await _usuarioRepository.GetUsuario();
            var user = resultado.Value as List<Usuario>;

            Assert.False(user.Any(x => x.CPF == "33322233308"));
        }
    }
}
