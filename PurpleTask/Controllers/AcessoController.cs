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
    public class AcessoController : ControllerBase
    {
        private readonly IAcessoRepositorio _acessoRepositorio;

        public AcessoController(IAcessoRepositorio acesso)
        {
            _acessoRepositorio = acesso;
        }

        [AllowAnonymous]
        [HttpGet("Login/{email}/{senha}")]

        public async Task<ActionResult<ResponseModel<AuthToken>>> Login(string email, string senha)
        {
            //senha = ConfigurationUtils.Criptografar(senha);
            var usuarios = await _acessoRepositorio.Login(email, senha);
            return Ok(usuarios);
        }


    }
}
