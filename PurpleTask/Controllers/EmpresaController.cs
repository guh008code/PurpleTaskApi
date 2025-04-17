using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurpleTask.Models;
using PurpleTask.Repositorios;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepositorio empresaRepositorio;

        public EmpresaController(IEmpresaRepositorio empresaRepositorio)
        {
            this.empresaRepositorio = empresaRepositorio;
        }

        [HttpGet("BuscarPorId/{idEmpresa}/{idInstalacao}")]
        [Authorize(Roles = "empresa")]
        public async Task<ActionResult<ResponseModel<Ep>>> BuscarPorId(int? idEmpresa, int? idInstalacao)
        {
            var empresa = await empresaRepositorio.BuscarPorId(idEmpresa, idInstalacao);
            return Ok(empresa);
        }

        [HttpGet("ListarTodos/{idInstalacao}")]
        [Authorize(Roles = "empresa")]
        public async Task<ActionResult<ResponseModel<List<Ep>>>> ListarTodos(int? idInstalacao)
        {
            var empresas = await empresaRepositorio.ListarTodos(idInstalacao);
            return Ok(empresas);
        }

    }
}
