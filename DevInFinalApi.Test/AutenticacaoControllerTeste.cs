using DevInFinalApi.Controllers;
using Domain.DTOs;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DevInFinalApi.Test
{
    public class AutenticacaoControllerTeste
    {
        private Mock<IAutenticacaoService> _autenticacaoServiceMock;
        private AutenticacaoController _controller;

        [SetUp]
        public void Setup()
        {
            _autenticacaoServiceMock = new Mock<IAutenticacaoService>();
            _controller = new AutenticacaoController(_autenticacaoServiceMock.Object);
        }

        [Test]
        public async Task Test_AutenticarUsuario_Returns_Token()
        {
            var mockService = new Mock<IAutenticacaoService>();
            var expectedToken = "test_token";

            mockService.Setup(s => s.AutenticarUsuario(It.IsAny<LoginDTO>())).ReturnsAsync(expectedToken);
            
            var controller = new AutenticacaoController(mockService.Object);
            var dto = new LoginDTO { Email = "test@test.com", Senha = "password" };
            var result = await controller.AuthenticateAsync(dto);
            var okResult = result.Result as OkObjectResult;
            
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult.Value is string);
            
            var returnValue = okResult.Value as string;
            
            Assert.AreEqual(expectedToken, returnValue);
        }
    }
}
