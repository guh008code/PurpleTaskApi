using Microsoft.EntityFrameworkCore;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Repositorios
{
    public class AcessoRepositorio : IAcessoRepositorio
    {
        private readonly PurpleMgmContext _dbContext;
        public AcessoRepositorio(PurpleMgmContext purpleTaskDBContex)
        {
            _dbContext = purpleTaskDBContex;
        }

        public async Task<ResponseModel<AuthToken>> Login(Login login)
        {
            ResponseModel<AuthToken> resposta = new ResponseModel<AuthToken>();
            resposta.Dados = new AuthToken();

            login.Senha = ConfigurationUtils.Criptografar(login.Senha.Replace("'",""));
            try
            {

                var usuarios = await _dbContext.Usrs.FirstOrDefaultAsync(user => user.UsrEma.ToLower() == login.Email.ToLower() && user.UsrSnh == login.Senha);

                if (usuarios == null)
                {
                    resposta.Mensagem = "Login inválido";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados.IdUser = usuarios.UsrId.ToString();
                resposta.Dados.IdEmpresa = usuarios.UsrEpsId.ToString();
                resposta.Dados.Nome = usuarios.UsrNom;
                resposta.Dados.IdPerfil = usuarios.UsrPfl.ToString();
                resposta.Dados.Email = usuarios.UsrEma;
                resposta.Dados.Instalacao = usuarios.UsrIstId.ToString();
                resposta.Dados.AcessToken = ConfigurationUtils.GenerateToken(usuarios);

                resposta.Mensagem = "Login e token gerado com sucesso.";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
