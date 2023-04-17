using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using Domain.Service;
using Moq;

namespace DomainUnit.Test
{
    [TestFixture]
    public class AutenticacaoServiceTeste
    {
        private Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private Mock<ITokenService> _tokenServiceMock;
        private AutenticacaoService _autenticacaoService;

        [SetUp]
        public void SetUp()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _tokenServiceMock = new Mock<ITokenService>();
            _autenticacaoService = new AutenticacaoService(_usuarioRepositoryMock.Object, _tokenServiceMock.Object);
        }

        [Test]
        public async Task AutenticarUsuario_WithValidCredentials_ReturnsToken()
        {
            var email = "test@test.com";
            var senha = "123456";
            var usuario = new Usuario
            {
                Email = email,
                Senha = senha
            };
            var expectedToken = "token";

            _usuarioRepositoryMock.Setup(x => x.GetUsuarioByDto(It.IsAny<LoginDTO>()))
                .ReturnsAsync(usuario);

            _tokenServiceMock.Setup(x => x.GenerateToken(It.IsAny<Usuario>()))
                .Returns(expectedToken);

            var result = await _autenticacaoService.AutenticarUsuario(new LoginDTO
            {
                Email = email,
                Senha = senha
            });

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedToken, result.Value);
        }

        [Test]
        public async Task AutenticarUsuario_WithInvalidCredentials_ReturnsErrorMessage()
        {
            var email = "test@test.com";
            var senha = "123456";
            Usuario usuario = null;

            _usuarioRepositoryMock.Setup(x => x.GetUsuarioByDto(It.IsAny<LoginDTO>()))
                .ReturnsAsync(usuario);

            var result = await _autenticacaoService.AutenticarUsuario(new LoginDTO
            {
                Email = email,
                Senha = senha
            });

            Assert.IsNotNull(result);
            Assert.AreEqual("Usuário e/ou senha inválidos.", result.Value);
        }

        [Test]
        public async Task AutenticarUsuario_WithException_ReturnsErrorMessage()
        {
            var email = "test@test.com";
            var senha = "123456";

            _usuarioRepositoryMock.Setup(x => x.GetUsuarioByDto(It.IsAny<LoginDTO>()))
                .ThrowsAsync(new System.Exception());

            var result = await _autenticacaoService.AutenticarUsuario(new LoginDTO
            {
                Email = email,
                Senha = senha
            });

            Assert.IsNotNull(result);
            Assert.AreEqual("Ocorreu um erro durante o processo de geração do token.", result.Value);
        }
    }
}