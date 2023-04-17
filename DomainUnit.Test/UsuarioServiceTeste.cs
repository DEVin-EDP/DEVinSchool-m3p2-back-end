using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DomainUnit.Test
{
    [TestFixture]
    public class UsuarioServiceTeste
    {
        private UsuarioService _usuarioService;
        private Mock<IUsuarioRepository> _mockUsuarioRepository;
        private List<Usuario> usuarios;

        [SetUp]
        public void SetUp()
        {
            _mockUsuarioRepository = new Mock<IUsuarioRepository>();
            _usuarioService = new UsuarioService(_mockUsuarioRepository.Object);
        }

        [Test]
        public async Task TestGetUsuario()
        {
            var usuarios = new List<Usuario>
            {
                new Usuario { Nome = "Usuário 1", CPF = "12345678901", Idade = 30, Email = "usuario1@teste.com", Senha = "senha123", Foto = "foto1.jpg", UsuarioAtivo = true },
                new Usuario { Nome = "Usuário 2", CPF = "23456789012", Idade = 25, Email = "usuario2@teste.com", Senha = "senha456", Foto = "foto2.jpg", UsuarioAtivo = false },
                new Usuario { Nome = "Usuário 3", CPF = "34567890123", Idade = 40, Email = "usuario3@teste.com", Senha = "senha789", Foto = "foto3.jpg", UsuarioAtivo = true }
            };

            _mockUsuarioRepository.Setup(r => r.GetUsuario()).ReturnsAsync(usuarios);

            var result = await _usuarioService.GetUsuario();

            var users = result.Value as List<Usuario>;

            Assert.That(users, Is.EquivalentTo(usuarios));
        }

        [Test]
        public async Task TestGetUsuarioByid()
        {
            int id = 1;
            var expectedUsuario = new Usuario { Id = id, Nome = "João", CPF = "12345678901", Idade = 30 };
            var usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock.Setup(repo => repo.GetUsuario(id)).ReturnsAsync(expectedUsuario);
            var usuarioService = new UsuarioService(usuarioRepositoryMock.Object);

            var result = await usuarioService.GetUsuario(id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Usuario>(result.Value);
            Assert.AreEqual(expectedUsuario, result.Value);
        }
        [Test]
        public async Task TestPutUsuario()
        {
            int id = 1;
            UsuarioPutRequest request = new UsuarioPutRequest
            {
                Nome = "João",
                Idade = 30,
                Senha = "senha123"
            };

            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(x => x.PutUsuario(id, request))
                .ReturnsAsync(new Usuario { Nome = request.Nome, Idade = request.Idade });

            var service = new UsuarioService(mockRepository.Object);
            var result = await service.PutUsuario(id, request);


            Assert.IsInstanceOf<ActionResult<dynamic>>(result);
            var okResult = result.Value as Usuario;
            Assert.IsInstanceOf<Usuario>(okResult);
            Assert.AreEqual(request.Nome, okResult.Nome);
            Assert.AreEqual(request.Idade, okResult.Idade);
            mockRepository.Verify(x => x.PutUsuario(id, request), Times.Once);
        }

        [Test]
        public async Task TestPostUsuario()
        {
            UsuarioRequest request = new UsuarioRequest
            {   
                Nome = "João",
                Idade = 30,
                Cpf = "01965187251",
                Email = "teste@mail.com",
                Senha = "senha123",
                Foto = "C:\\Users\neeet\\OneDrive\\Imagens\\Baixadas\\GC.jpg"
            };
            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(x => x.PostUsuario(request))
               .ReturnsAsync(new Usuario
               {
                   Nome = request.Nome,
                   Idade = request.Idade,
                   CPF = request.Cpf,
                   Email = request.Email,
                   Senha = request.Senha,
                   Foto = request.Foto
               });
            var service = new UsuarioService(mockRepository.Object);
            var result = await service.PostUsuario(request);

            Assert.IsInstanceOf<ActionResult<dynamic>>(result);

            var okResult = result.Value as Usuario;

            Assert.IsInstanceOf<Usuario>(okResult);
            Assert.AreEqual(request.Nome, okResult.Nome);
            Assert.AreEqual(request.Idade, okResult.Idade);

            mockRepository.Verify(x => x.PostUsuario(request), Times.Once);
        }
        [Test]
        public async Task TestDeleteUsuario()
        {
            int id = 5;
            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(x => x.DeleteUsuario(id))
               .ReturnsAsync(true);
            
            var service = new UsuarioService(mockRepository.Object);
            var result = await service.DeleteUsuario(id);

            Assert.IsInstanceOf<ActionResult<dynamic>>(result);
            Assert.IsTrue(result.Value == result.Value);

             mockRepository.Verify(x => x.DeleteUsuario(id), Times.Once);
        }
    }
}
