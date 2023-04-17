using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DomainUnit.Test
{
    [TestFixture]
    public class CursoServiceTeste
    {
        private Mock<ICursoRepository> _mockCursoRepository;
        private CursoService _cursoService;

        [SetUp]
        public void SetUp()
        {
            _mockCursoRepository = new Mock<ICursoRepository>();
            _cursoService = new CursoService(_mockCursoRepository.Object);
        }

        [Test]
        public async Task GetCurso_DeveRetornarListaDeCursos()
        {
            var expectedCursos = new List<Curso>();
            _mockCursoRepository.Setup(repo => repo.GetCurso())
                .ReturnsAsync(expectedCursos);

            var result = await _cursoService.GetCurso();

            Assert.IsInstanceOf<ActionResult<dynamic>>(result);
            Assert.AreEqual(expectedCursos, result.Value);
        }

        [Test]
        public async Task GetCurso_DeveRetornarCursoPorId()
        {
            var id = 1;
            var expectedCurso = new Curso { Id = id };
            _mockCursoRepository.Setup(repo => repo.GetCurso(id))
                .ReturnsAsync(expectedCurso);

            var result = await _cursoService.GetCurso(id);

            Assert.IsInstanceOf<ActionResult<dynamic>>(result);
            Assert.AreEqual(expectedCurso, result.Value);
        }

        [Test]
        public async Task GetCursoCategoria_DeveRetornarListaDeCursosPorCategoria()
        {
            var categoriaId = 1;
            var expectedCursos = new List<Curso>();
            _mockCursoRepository.Setup(repo => repo.GetCursoCategoria(categoriaId))
                .ReturnsAsync(expectedCursos);

            var result = await _cursoService.GetCursoCategoria(categoriaId);

            Assert.IsInstanceOf<ActionResult<dynamic>>(result);
            Assert.AreEqual(expectedCursos, result.Value);
        }

        [Test]
        public async Task GetCursoPesquisa_DeveRetornarListaDeCursosPorTermoDePesquisa()
        {
            var termoPesquisa = "ASP.NET Core";
            var expectedCursos = new List<Curso>();
            _mockCursoRepository.Setup(repo => repo.GetCursoPesquisa(termoPesquisa))
                .ReturnsAsync(expectedCursos);

            var result = await _cursoService.GetCursoPesquisa(termoPesquisa);

            Assert.IsInstanceOf<ActionResult<dynamic>>(result);
            Assert.AreEqual(expectedCursos, result.Value);
        }

        [Test]
        public async Task PutCurso_DeveAtualizarCurso()
        {
            var id = 1;
            var cursoPostRequest = new CursoPostRequest { Nome = "Novo nome do curso" };
            var expectedResponse = new ObjectResult(new { Message = "Curso atualizado com sucesso!" })
            {
                StatusCode = StatusCodes.Status200OK
            };
            _mockCursoRepository.Setup(repo => repo.PutCurso(id, cursoPostRequest))
                .ReturnsAsync(expectedResponse);

            var result = await _cursoService.PutCurso(id, cursoPostRequest);

            Assert.IsInstanceOf<ActionResult<dynamic>>(result);
            Assert.AreEqual(expectedResponse, result.Result);
        }

        [Test]
        public async Task PostCurso_DeveCriarNovoCurso()
        {
            var cursoPostRequest = new CursoPostRequest
            {
                Nome = "Curso de Testes com NUnit",
                Informacao = "Aprenda a escrever testes com NUnit",
                Resumo = "Aprenda a escrever testes com NUnit",
                CargaHoraria = 40,
                Link = "https://exemplo.com/curso-de-testes-nunit",
                CursoAtivo = true,
                CategoriaCursoId = 1
            };

            var expected = new Curso
            {
                Id = 1,
                Nome = "Curso de Testes com NUnit",
                Informacao = "Aprenda a escrever testes com NUnit",
                Resumo = "Aprenda a escrever testes com NUnit",
                CargaHoraria = 40,
                Link = "https://exemplo.com/curso-de-testes-nunit",
                CursoAtivo = true,
                CategoriaCursoId = 1
            };

            _mockCursoRepository.Setup(x => x.PostCurso(It.IsAny<CursoPostRequest>()))
                .ReturnsAsync(new ActionResult<dynamic>(new { id = 1 }));

            var result = await _cursoService.PostCurso(cursoPostRequest);

            _mockCursoRepository.Verify(x => x.PostCurso(cursoPostRequest), Times.Once);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ActionResult<dynamic>>(result);
            Assert.AreEqual(expected.Id, result.Value.id);
        }
        [Test]
        public async Task DeleteCurso_DeveRemoverCurso()
        {
            int cursoId = 1;
            var cursoRepositoryMock = new Mock<ICursoRepository>();
            cursoRepositoryMock.Setup(repo => repo.DeleteCurso(cursoId)).ReturnsAsync(new OkResult());

            var cursoService = new CursoService(cursoRepositoryMock.Object);
            var result = await cursoService.DeleteCurso(cursoId);

            cursoRepositoryMock.Verify(repo => repo.DeleteCurso(cursoId), Times.Once);
            Assert.IsInstanceOf<OkResult>(result.Value);
        }
    }
}
