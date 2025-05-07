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
        [HttpPost("Login/")]

        public async Task<ActionResult<ResponseModel<AuthToken>>> Login(Login login)
        {
            //senha = ConfigurationUtils.Criptografar(senha);
            var usuarios = await _acessoRepositorio.Login(login);
            return Ok(usuarios);
        }
        [HttpPut("Atualizar")]
        [Authorize(Roles = "acesso")]
        public async Task<ActionResult<ResponseModel<Usr>>> Atualizar(Usr atualizar)
        {
            //senha = ConfigurationUtils.Criptografar(senha);
            var usuario = await _acessoRepositorio.Atualizar(atualizar);
            return Ok(usuario);
        }

    }
}
