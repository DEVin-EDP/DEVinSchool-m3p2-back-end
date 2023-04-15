using Domain.Interfaces;
using Domain.Models;
using Domain.Service;
using Moq;

namespace DomainUnit.Test
{
    [TestFixture]
    public class UsuarioServiceTeste
    {
        private UsuarioService _usuarioService;
        private Mock<IUsuarioRepository> _mockUsuarioRepository;

        [SetUp]
        public void SetUp()
        {
            _mockUsuarioRepository = new Mock<IUsuarioRepository>();
            _usuarioService = new UsuarioService(_mockUsuarioRepository.Object);
        }

        [Test]
        public async Task GetUsuario_ReturnaUsuarios()
        {
            var usuarios = new List<Usuario>
            {
                new Usuario { Nome = "Usuário 1", CPF = "12345678901", Idade = 30, Email = "usuario1@teste.com", Senha = "senha123", Foto = "foto1.jpg", UsuarioAtivo = true },
                new Usuario { Nome = "Usuário 2", CPF = "23456789012", Idade = 25, Email = "usuario2@teste.com", Senha = "senha456", Foto = "foto2.jpg", UsuarioAtivo = false },
                new Usuario { Nome = "Usuário 3", CPF = "34567890123", Idade = 40, Email = "usuario3@teste.com", Senha = "senha789", Foto = "foto3.jpg", UsuarioAtivo = true }
            };

            _mockUsuarioRepository.Setup(r => r.GetUsuario()).ReturnsAsync(usuarios);

            var result = await _usuarioService.GetUsuario();

            Assert.That(result, Is.EquivalentTo(usuarios));
        }
    }
}
