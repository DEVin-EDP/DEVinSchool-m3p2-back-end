using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DomainUnit.Test
{
    [TestFixture]
    public class CategoriaCursoServiceTeste
    {
        private Mock<ICategoriaCursoRepository> _categoriaCursoRepositoryMock;
        private CategoriaCursoService _categoriaCursoService;

        [SetUp]
        public void SetUp()
        {
            _categoriaCursoRepositoryMock = new Mock<ICategoriaCursoRepository>();
            _categoriaCursoService = new CategoriaCursoService(_categoriaCursoRepositoryMock.Object);
        }

        [Test]
        public async Task GetCategoriaCurso_ReturnActionResult()
        {
            var categoriaCursos = new List<CategoriaCurso>
            {
                new CategoriaCurso { Id = 1, Titulo = "Tecnologia" },
                new CategoriaCurso { Id = 2, Titulo = "Administração" },
                new CategoriaCurso { Id = 3, Titulo = "Marketing" },
                new CategoriaCurso { Id = 4, Titulo = "Design" }
            };
            _categoriaCursoRepositoryMock.Setup(x => x.GetCategoriaCurso()).ReturnsAsync(categoriaCursos);

            var result = await _categoriaCursoService.GetCategoriaCurso();

            Assert.IsInstanceOf<ActionResult<dynamic>>(result);
            Assert.AreEqual(categoriaCursos, result.Value);
        }

        [Test]
        public async Task GetCategoriaCursoId_ReturnActionResult()
        {

            var categoriaCurso = new CategoriaCurso { Id = 1, Titulo = "Tecnologia" };
            _categoriaCursoRepositoryMock.Setup(x => x.GetCategoriaCurso(1)).ReturnsAsync(categoriaCurso);

            var result = await _categoriaCursoService.GetCategoriaCurso(1);


            Assert.IsInstanceOf<ActionResult<dynamic>>(result);
            Assert.AreEqual(categoriaCurso, result.Value);
        }

        public async Task PostCategoriaCurso_ReturnActionResult()
        {
            var request = new CategoriaCursoRequestDto { Titulo = "Nova Categoria" };
            var categoriaCurso = new CategoriaCurso { Id = 5, Titulo = "Nova Categoria" };
            _categoriaCursoRepositoryMock.Setup(x => x.PostCategoriaCurso(request)).ReturnsAsync(categoriaCurso);

            var result = await _categoriaCursoService.PostCategoriaCurso(request);

            Assert.IsInstanceOf<ActionResult<dynamic>>(result);
            Assert.AreEqual(categoriaCurso, result.Value);
        }

        [Test]
        public async Task PutCategoriaCurso_ReturnActionResult()
        {
            var id = 5;
            var categoriaCurso = new CategoriaCurso { Id = id, Titulo = "Categoria teste" };
            var request = new CategoriaCursoRequestDto { Titulo = "Nova Categoria" };
            _categoriaCursoRepositoryMock.Setup(x => x.PutCategoriaCurso(id, request)).ReturnsAsync(categoriaCurso);

            var result = await _categoriaCursoService.PutCategoriaCurso(id, request);

            Assert.IsInstanceOf<ActionResult<dynamic>>(result);
            Assert.AreEqual(categoriaCurso, result.Value);
        }

        [Test]
        public async Task DeleteCategoriaCurso_ReturnActionResult()
        {
            var id = 5;
            var categoriaCurso = new CategoriaCurso { Id = id, Titulo = "Categoria Atualizada" };
            _categoriaCursoRepositoryMock.Setup(x => x.DeleteCategoriaCurso(id)).ReturnsAsync(categoriaCurso);

            var result = await _categoriaCursoService.DeleteCategoriaCurso(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(categoriaCurso, result.Value);
        }
    }
}