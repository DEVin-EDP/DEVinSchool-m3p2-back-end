using AutoMapper;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using DevInFinalApi.Controllers;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Domain.Service;
using NuGet.Protocol;

namespace Infrastructure.Test
{
    [TestFixture]
    internal class CursoRepositoryTeste
    {
        private Mock<ApplicationContext> _contextMock;
        private ICursoRepository _repository;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _contextMock = new Mock<ApplicationContext>();
            _repository = new CursoRepository(_contextMock.Object); 
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Curso, CursosTelaInicialRequest>();
            });
            _mapper = config.CreateMapper();
        }

        [Test]
        public async Task GetCurso_DeveRetornarListaDeCursos()
        {
            var cursos = new List<Curso>
            {
                new Curso { Id = 1, Nome = "Curso 1", Resumo = "Resumo 1", Informacao = "Informação 1", Link = "Link 1", CargaHoraria = 10, CursoAtivo = true, CategoriaCursoId = 1 },
                new Curso { Id = 2, Nome = "Curso 2", Resumo = "Resumo 2", Informacao = "Informação 2", Link = "Link 2", CargaHoraria = 20, CursoAtivo = false, CategoriaCursoId = 1 }
            };
            _contextMock.Setup(c => c.Curso);

            var result = await _repository.GetCurso();

            Assert.IsInstanceOf<List<CursoResponse>>(result.Value);
            Assert.AreEqual(2, result.Value.Count());
            Assert.AreEqual(1, result.Value[0].Id);
            Assert.AreEqual("Curso 1", result.Value[0].Nome);
            Assert.AreEqual("Resumo 1", result.Value[0].Resumo);
            Assert.AreEqual("Informação 1", result.Value[0].Informacao);
            Assert.AreEqual("Link 1", result.Value[0].Link);
            Assert.AreEqual(10, result.Value[0].CargaHoraria);
            Assert.AreEqual(true, result.Value[0].CursoAtivo);
            Assert.AreEqual(1, result.Value[0].CategoriaCursoId);
        }

        [Test]
        public async Task GetCurso_Deve_Retornar_Curso_Quando_Existir()
        {
            var curso = new Curso { Id = 1, Nome = "Curso de teste" };
            _contextMock.Setup(c => c.Curso.FindAsync(1)).ReturnsAsync(curso);

            var result = await _repository.GetCurso(1);
            Assert.That(result.Value, Is.EqualTo(curso));
        }

        [Test]
        public async Task GetCurso_Deve_Retornar_Message_Quando_Curso_Nao_Existir()
        {
            _contextMock.Setup(c => c.Curso.FindAsync(1)).ReturnsAsync(null as Curso);
            var result = await _repository.GetCurso(1);
            Assert.That(result.Value.Message, Is.EqualTo("Não foi possível retornar a informação."));
        }

        [Test]
        public async Task GetCurso_Deve_Retornar_Message_Quando_Ocorrer_Erro()
        {
            _contextMock.Setup(c => c.Curso.FindAsync(1)).Throws(new System.Exception());
            var result = await _repository.GetCurso(1);
            Assert.That(result.Value.Message, Is.EqualTo("Ocorreu erro durante o retorno dos dados dos cursos."));
        }
        [Test]
        public async Task GetCursoCategoria_DeveRetornarListaDeCursos()
        {
            // Arrange
            int categoriaId = 1;
            var cursoList = new List<Curso>
        {
            new Curso { Id = 1, Nome = "Curso 1", CategoriaCursoId = categoriaId },
            new Curso { Id = 2, Nome = "Curso 2", CategoriaCursoId = categoriaId }
        }.AsQueryable();

            var categoriaList = new List<CategoriaCurso>
        {
            new CategoriaCurso { Id = categoriaId, Titulo = "Categoria 1" }
        }.AsQueryable();

            var cursoDbSetMock = new Mock<DbSet<Curso>>();
            cursoDbSetMock.As<IQueryable<Curso>>().Setup(m => m.Provider).Returns(cursoList.Provider);
            cursoDbSetMock.As<IQueryable<Curso>>().Setup(m => m.Expression).Returns(cursoList.Expression);
            cursoDbSetMock.As<IQueryable<Curso>>().Setup(m => m.ElementType).Returns(cursoList.ElementType);
            cursoDbSetMock.As<IQueryable<Curso>>().Setup(m => m.GetEnumerator()).Returns(cursoList.GetEnumerator());

            var categoriaDbSetMock = new Mock<DbSet<CategoriaCurso>>();
            categoriaDbSetMock.As<IQueryable<CategoriaCurso>>().Setup(m => m.Provider).Returns(categoriaList.Provider);
            categoriaDbSetMock.As<IQueryable<CategoriaCurso>>().Setup(m => m.Expression).Returns(categoriaList.Expression);
            categoriaDbSetMock.As<IQueryable<CategoriaCurso>>().Setup(m => m.ElementType).Returns(categoriaList.ElementType);
            categoriaDbSetMock.As<IQueryable<CategoriaCurso>>().Setup(m => m.GetEnumerator()).Returns(categoriaList.GetEnumerator());

            _contextMock.Setup(x => x.Curso).Returns(cursoDbSetMock.Object);
            _contextMock.Setup(x => x.CategoriaCurso).Returns(categoriaDbSetMock.Object);

            var repository = new CursoRepository(_contextMock.Object);
            var result = await repository.GetCursoCategoria(categoriaId);

            Assert.IsInstanceOf<List<CursosTelaInicialRequest>>(result);
        }

        [Test]
        public async Task GetCursoCategoria_DeveRetornarMensagemDeErro_QuandoContextForNulo()
        {
            // Arrange
            int categoriaId = 1;
            _contextMock.Setup(x => x.Curso).Returns<DbSet<Curso>>(null);

            var repository = new CursoRepository(_contextMock.Object);

            // Act
            var result = await repository.GetCursoCategoria(categoriaId);

            // Assert
            Assert.AreEqual("Não foi possível retornar a informação.", result.Value);
        }
    }
}
