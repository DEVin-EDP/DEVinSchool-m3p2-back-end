using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Infrastructure.Test
{
    public class CategoriaCursoRepositoryTeste
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
        public async Task GetCategoriaCurso_ReturnsCorrectObject()
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
        public async Task GetCategoriaCursoId_ReturnsCorrectObject()
        {

            var categoriaCurso = new CategoriaCurso { Id = 1, Titulo = "Tecnologia" };
            _categoriaCursoRepositoryMock.Setup(x => x.GetCategoriaCurso(1)).ReturnsAsync(categoriaCurso);

            var result = await _categoriaCursoService.GetCategoriaCurso(1);

            Assert.AreEqual(categoriaCurso, result.Value);
        }

        [Test]
        public async Task GetCategoriaCursoId_ReturnsError()
        { 

            var categoriaCurso = new CategoriaCurso { Id = 6, Titulo = "Tecnologia" };
            _categoriaCursoRepositoryMock.Setup(x => x.GetCategoriaCurso(6)).ReturnsAsync(categoriaCurso);

            var result = await _categoriaCursoService.GetCategoriaCurso(6);

            Assert.AreEqual(categoriaCurso, result.Value);
        }

        [Test]
        public async Task PostCategoriaCurso_ReturnsCorrectObject()
        {
            var request = new CategoriaCursoRequestDto { Titulo = "Nova Categoria" };
            var categoriaCurso = new CategoriaCurso { Id = 5, Titulo = "Nova Categoria" };
            _categoriaCursoRepositoryMock.Setup(x => x.PostCategoriaCurso(request)).ReturnsAsync(categoriaCurso);

            var result = await _categoriaCursoService.PostCategoriaCurso(request);

            Assert.AreEqual(categoriaCurso, result.Value);
        }

        [Test]
        public async Task PostCategoriaCurso_ReturnsError()
        {
            var request = new CategoriaCursoRequestDto { Titulo = "Tecnologia" };
            var categoriaCurso = new CategoriaCurso { Id = 1, Titulo = "Tecnologia" };
            _categoriaCursoRepositoryMock.Setup(x => x.PostCategoriaCurso(request)).ReturnsAsync(categoriaCurso);

            var result = await _categoriaCursoService.PostCategoriaCurso(request);

            Assert.AreEqual(categoriaCurso, result.Value);
        }

        [Test]
        public async Task PutCategoriaCurso_ReturnsCorrectObject()
        {
            var id = 5;
            var categoriaCurso = new CategoriaCurso { Id = id, Titulo = "Categoria teste" };
            var request = new CategoriaCursoRequestDto { Titulo = "Nova Categoria" };
            _categoriaCursoRepositoryMock.Setup(x => x.PutCategoriaCurso(id, request)).ReturnsAsync(categoriaCurso);

            var result = await _categoriaCursoService.PutCategoriaCurso(id, request);

            Assert.AreEqual(categoriaCurso, result.Value);
        }

        [Test]
        public async Task PutCategoriaCurso_ReturnsError()
        {
            var id = 6;
            var categoriaCurso = new CategoriaCurso { Id = id, Titulo = "CategoriaId teste" };
            var request = new CategoriaCursoRequestDto { Titulo = "Categoria teste" };
            _categoriaCursoRepositoryMock.Setup(x => x.PutCategoriaCurso(id, request)).ReturnsAsync(categoriaCurso);

            var result = await _categoriaCursoService.PutCategoriaCurso(id, request);

            Assert.AreEqual(categoriaCurso, result.Value);
        }

        [Test]
        public async Task DeleteCategoriaCurso_ReturnsCorrectObject()
        {
            var id = 5;
            var categoriaCurso = new CategoriaCurso { Id = id, Titulo = "Categoria teste" };
            _categoriaCursoRepositoryMock.Setup(x => x.DeleteCategoriaCurso(id)).ReturnsAsync(categoriaCurso);

            var result = await _categoriaCursoService.DeleteCategoriaCurso(id);

            Assert.AreEqual(categoriaCurso, result.Value);
        }

        [Test]
        public async Task DeleteCategoriaCurso_ReturnsError()
        {
            var id = 6;
            var categoriaCurso = new CategoriaCurso { Id = id, Titulo = "Categoria teste" };
            _categoriaCursoRepositoryMock.Setup(x => x.DeleteCategoriaCurso(id)).ReturnsAsync(categoriaCurso);

            var result = await _categoriaCursoService.DeleteCategoriaCurso(id);

            Assert.AreEqual(categoriaCurso, result.Value);
        }
    }
}