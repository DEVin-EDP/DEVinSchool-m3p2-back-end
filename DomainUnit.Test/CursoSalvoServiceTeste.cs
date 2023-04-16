using Domain.Abstract;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DomainUnit.Test
{
    public class CursoSalvoServiceTeste
    {
        private Mock<ICursoSalvoRepository> _mockRepository;
        private CursoSalvoService _service;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<ICursoSalvoRepository>();
            _service = new CursoSalvoService(_mockRepository.Object);
        }

        [Test]
        public async Task GetCursoSalvo_ShouldReturnListOfCursoSalvoResponses()
        {
            // Arrange
            var cursoSalvoList = new List<CursoSalvo>()
        {
            new CursoSalvo()
            {
                Id = 1,
                UsuarioId = 1,
                CursoId = 1,
                StatusCurso = StatusCursoEnum.CONCLUIDO,
                DataCursoSalvo = DateTime.Now,
                Usuario = new Usuario(),
                Curso = new Curso()
            }
        };

            var expectedResponseList = cursoSalvoList.Select(cs => new CursoSalvoResponse()
            {
                Id = cs.Id,
                UsuarioId = cs.UsuarioId,
                CursoId = cs.CursoId,
                StatusCurso = cs.StatusCurso.ToString(),
                DataCursoSalvo = cs.DataCursoSalvo,
                Nome = cs.Curso.Nome,
                Informacao = cs.Curso.Informacao,
                Resumo = cs.Curso.Resumo,
                CargaHoraria = cs.Curso.CargaHoraria,
                Link = cs.Curso.Link,
                CategoriaCurso = cs.Curso.CategoriaCurso.ToString()
            }).ToList();

            _mockRepository.Setup(repo => repo.GetCursoSalvo()).ReturnsAsync(cursoSalvoList);

            // Act
            var response = await _service.GetCursoSalvo();

            // Assert
            Assert.IsInstanceOf<ActionResult<List<CursoSalvoResponse>>>(response);
            Assert.AreEqual(expectedResponseList.Count, response.Value.Count);
            for (int i = 0; i < expectedResponseList.Count; i++)
            {
                Assert.AreEqual(expectedResponseList[i].Id, response.Value[i].Id);
                Assert.AreEqual(expectedResponseList[i].UsuarioId, response.Value[i].UsuarioId);
                Assert.AreEqual(expectedResponseList[i].CursoId, response.Value[i].CursoId);
                Assert.AreEqual(expectedResponseList[i].StatusCurso, response.Value[i].StatusCurso);
                Assert.AreEqual(expectedResponseList[i].DataCursoSalvo, response.Value[i].DataCursoSalvo);
                Assert.AreEqual(expectedResponseList[i].Nome, response.Value[i].Nome);
                Assert.AreEqual(expectedResponseList[i].Informacao, response.Value[i].Informacao);
                Assert.AreEqual(expectedResponseList[i].Resumo, response.Value[i].Resumo);
                Assert.AreEqual(expectedResponseList[i].CargaHoraria, response.Value[i].CargaHoraria);
                Assert.AreEqual(expectedResponseList[i].Link, response.Value[i].Link);
                Assert.AreEqual(expectedResponseList[i].CategoriaCurso, response.Value[i].CategoriaCurso);
            }
        }
    }
}
