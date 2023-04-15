﻿using Azure.Core;
using Domain.DTOs;
using Domain.Models;
using Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevInFinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _CursoService;
        public CursoController(ICursoService CursoService)
        {
            _CursoService = CursoService;
        }

        [HttpGet]
        [Authorize(Roles = ("usuario, admin"))]
        public async Task<ActionResult<dynamic>> GetCurso()
        {
            return await _CursoService.GetCurso();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = ("usuario, admin"))]
        public async Task<ActionResult<dynamic>> GetCurso(int id)
        {
            return await _CursoService.GetCurso(id);
        }

        [HttpGet("categoria")]
        [Authorize(Roles = ("usuario, admin"))]
        public async Task<ActionResult<dynamic>> GetCursoCategoria(int id)
        {
            return await _CursoService.GetCursoCategoria(id);
        }

        [HttpPost]
        [Authorize(Roles = ("admin"))]
        public async Task<ActionResult<dynamic>> PostCurso(CursoResponse request)
        {
            return await _CursoService.PostCurso(request);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = ("admin"))]
        public async Task<ActionResult<dynamic>> PutCurso(int id, CursoResponse request)
        {
            return await _CursoService.PutCurso(id, request);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = ("admin"))]
        public async Task<ActionResult<dynamic>> DeleteCurso(int id)
        {
            return await _CursoService.DeleteCurso(id);
        }
    }
}
