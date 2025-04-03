using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Repositorios
{
    public class LocalRepositorio : ILocalRepositorio
    {
        private readonly PurpleMgmContext _dbContext;
        public LocalRepositorio(PurpleMgmContext purpleTaskDBContex)
        {
            _dbContext = purpleTaskDBContex;
        }

        public async Task<ResponseModel<Loc>> BuscarPorId(int id, int? idEmpresa, int idInstalacao)
        {
            ResponseModel<Loc> resposta = new ResponseModel<Loc>();
            try
            {
                if (!string.IsNullOrEmpty(id.ToString()) && !string.IsNullOrEmpty(idEmpresa.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {
                    var usuarios = await _dbContext.Locs.FirstOrDefaultAsync(x => x.LocId == id
                                                                            && x.LocEpsId == idEmpresa
                                                                            && x.LocIstId == idInstalacao);

                    if (usuarios == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        return resposta;
                    }

                    resposta.Dados = usuarios;
                    resposta.Mensagem = "Registro localizado";

                }
                else if (!string.IsNullOrEmpty(id.ToString()) && string.IsNullOrEmpty(idEmpresa.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {
                    var usuarios = await _dbContext.Locs.FirstOrDefaultAsync(x => x.LocId == id
                                                                            && x.LocIstId == idInstalacao);

                    if (usuarios == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        return resposta;
                    }

                    resposta.Dados = usuarios;
                    resposta.Mensagem = "Registro localizado";

                }

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
