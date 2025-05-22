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
    public class LeadController : ControllerBase
    {
        private readonly ILeadsRepositorio leadsRepositorio;

        public LeadController(ILeadsRepositorio leadsRepositorio)
        {
            this.leadsRepositorio = leadsRepositorio;
        }

        [HttpPost("ListarPorFiltros/")]
        [Authorize(Roles = "leads")]
        public async Task<ActionResult<ResponseModel<List<Led>>>> ListarPorFiltros(Led lead)
        {
            var leads = await leadsRepositorio.ListarPorFiltros(lead);
            return Ok(leads);
        }

        [HttpGet("ListarTodos/")]
        [Authorize(Roles = "leads")]
        public async Task<ActionResult<ResponseModel<List<Set>>>> ListarTodos()
        {
            var leads = await leadsRepositorio.ListarTodos();
            return Ok(leads);
        }

        [HttpPost("Adicionar")]
        [Authorize(Roles = "leads")]
        public async Task<ActionResult<ResponseModel<Led>>> Adicionar(Led lead)
        {
            var leads = await leadsRepositorio.Adicionar(lead);
            return Ok(leads);
        }

    }
}
