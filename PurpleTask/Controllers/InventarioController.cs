using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("ListarTodos/{idEmpresa}/{idInstalacao}")]
        [Authorize(Roles = "inventario")]
        public async Task<ActionResult<ResponseModel<List<AvlItm>>>> ListarTodos(int? idEmpresa, int? idInstalacao)
        {
            var inventario = await inventarioRepositorio.ListarTodos(idEmpresa, idInstalacao);
            return Ok(inventario);
        }

        [HttpGet("BuscarPorId/{idIventario}/{idEmpresa}/{idInstalacao}")]
        [Authorize(Roles = "inventario")]
        public async Task<ActionResult<ResponseModel<AvlItm>>> BuscarPorId(int? idIventario, int? idEmpresa, int? idInstalacao)
        {
            var inventarios = await inventarioRepositorio.BuscarPorId(idIventario, idEmpresa, idInstalacao);
            return Ok(inventarios);
        }

        [HttpGet("BuscarPlaqueta/{AvlItmPlq}/{idEmpresa}/{idInstalacao}")]
        [Authorize(Roles = "inventario")]
        public async Task<ActionResult<ResponseModel<AvlItm>>> BuscarPlaqueta(int? AvlItmPlq, int? idEmpresa, int? idInstalacao)
        {
            var inventarios = await inventarioRepositorio.BuscarPlaqueta(AvlItmPlq, idEmpresa, idInstalacao);
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
        public async Task<ActionResult<ResponseModel<List<AvlItm>>>> Apagar(int? idInventario)
        {
            var inventarios = await inventarioRepositorio.Apagar(idInventario);
            return Ok(inventarios);
        }
    }
}
