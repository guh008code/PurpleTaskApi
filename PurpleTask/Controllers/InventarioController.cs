﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioRepositorio inventarioRepositorio;

        public InventarioController(IInventarioRepositorio inventarioRepositorio)
        {
            this.inventarioRepositorio = inventarioRepositorio;
        }

        [HttpGet("ListarTodos")]
        [Authorize(Roles = "inventario")]
        public async Task<ActionResult<ResponseModel<List<AvlItm>>>> ListarTodos()
        {
            var usuarios = await inventarioRepositorio.ListarTodos();
            return Ok(usuarios);
        }

        [HttpGet("BuscarPorId/{idIventario}")]
        [Authorize(Roles = "inventario")]
        public async Task<ActionResult<ResponseModel<AvlItm>>> BuscarPorId(int idIventario)
        {
            var inventarios = await inventarioRepositorio.BuscarPorId(idIventario);
            return Ok(inventarios);
        }

        [HttpPost("Adicionar")]
        [Authorize(Roles = "inventario")]
        public async Task<ActionResult<ResponseModel<AvlItm>>> Adicionar(AvlItm inventario)
        {
            var inventarios = await inventarioRepositorio.Adicionar(inventario);
            return Ok(inventarios);
        }

        [HttpPut("Atualizar")]
        [Authorize(Roles = "inventario")]
        public async Task<ActionResult<ResponseModel<List<AvlItm>>>> Atualizar(AvlItm inventario)
        {
            var inventarios = await inventarioRepositorio.Atualizar(inventario);
            return Ok(inventarios);
        }

        [HttpPut("Apagar")]
        [Authorize(Roles = "inventario")]
        public async Task<ActionResult<ResponseModel<List<AvlItm>>>> Apagar(int idInventario)
        {
            var inventarios = await inventarioRepositorio.Apagar(idInventario);
            return Ok(inventarios);
        }
    }
}
