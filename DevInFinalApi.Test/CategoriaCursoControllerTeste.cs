using DevInFinalApi.Controllers;
using Domain.DTOs;
using Domain.Models;
using Domain.Service;
using Moq;

namespace DevInFinalApi.Test
{
    [TestFixture]
    public class CategoriaCursoControllerTeste
    {
        private Mock<ICategoriaCursoService> _mockCategoriaCursoService;
        private CategoriaCursoController _controller;

        [SetUp]
        public void Setup()
        {
            _mockCategoriaCursoService = new Mock<ICategoriaCursoService>();
            _controller = new CategoriaCursoController(_mockCategoriaCursoService.Object);
        }

        [Test]
        public async Task GetCategoriaCurso_ReturnsCategoriaCursos()
        {
            var expectedCategoriaCursos = new List<CategoriaCurso>
            {
                new CategoriaCurso { Id = 1, Titulo = "Tecnologia" },
                new CategoriaCurso { Id = 2, Titulo = "Administração" },
                new CategoriaCurso { Id = 3, Titulo = "Marketing" },
                new CategoriaCurso { Id = 4, Titulo = "Design" }
            };
            _mockCategoriaCursoService.Setup(x => x.GetCategoriaCurso()).ReturnsAsync(expectedCategoriaCursos);

            var result = await _controller.GetCategoriaCurso();

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCategoriaCursos, result.Value);
        }
        [Test]
        public async Task GetCategoriaCursoId_ReturnsCategoriaCurso()
        {

            var expectedCategoriaCurso = new CategoriaCurso { Id = 1, Titulo = "Tecnologia" };
            _mockCategoriaCursoService.Setup(x => x.GetCategoriaCurso(1)).ReturnsAsync(expectedCategoriaCurso);

            var result = await _controller.GetCategoriaCurso(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCategoriaCurso, result.Value);
        }

        [Test]
        public async Task PostCategoriaCurso_ReturnsCreatedCategoriaCurso()
        {
            var request = new CategoriaCursoRequestDto { Titulo = "Nova Categoria" };
            var expectedCategoriaCurso = new CategoriaCurso { Id = 5, Titulo = "Nova Categoria" };
            _mockCategoriaCursoService.Setup(x => x.PostCategoriaCurso(request)).ReturnsAsync(expectedCategoriaCurso);

            var result = await _controller.PostCategoriaCurso(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCategoriaCurso, result.Value);
        }

        [Test]
        public async Task PutCategoriaCurso_ReturnsUpdatedCategoriaCurso()
        {
            var request = new CategoriaCursoRequestDto { Titulo = "Categoria Atualizada" };
            var expectedCategoriaCurso = new CategoriaCurso { Id = 5, Titulo = "Categoria Atualizada" };
            _mockCategoriaCursoService.Setup(x => x.PutCategoriaCurso(1, request)).ReturnsAsync(expectedCategoriaCurso);

            var result = await _controller.PutCategoriaCurso(1, request);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCategoriaCurso, result.Value);
        }

        [Test]
        public async Task DeleteCategoriaCurso_ReturnsDeletedCategoriaCurso()
        {
            var expectedCategoriaCurso = new CategoriaCurso { Id = 5, Titulo = "Categoria Atualizada" };
            _mockCategoriaCursoService.Setup(x => x.DeleteCategoriaCurso(5)).ReturnsAsync(expectedCategoriaCurso);

            var result = await _controller.DeleteCategoriaCurso(5);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCategoriaCurso, result.Value);
        }
    }
}