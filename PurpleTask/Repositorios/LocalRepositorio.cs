using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;
using System.Linq;

namespace PurpleTask.Repositorios
{
    public class LocalRepositorio : ILocalRepositorio
    {
        private readonly PurpleMgmContext _dbContext;
        public LocalRepositorio(PurpleMgmContext purpleTaskDBContex)
        {
            _dbContext = purpleTaskDBContex;
        }

        public async Task<ResponseModel<Loc>> BuscarPorId(int? id, int? idEmpresa, int? idInstalacao)
        {
            ResponseModel<Loc> resposta = new ResponseModel<Loc>();
            try
            {
                if (!string.IsNullOrEmpty(id.ToString()) && !string.IsNullOrEmpty(idEmpresa.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {
                    var local = await _dbContext.Locs.FirstOrDefaultAsync(x => x.LocId == id
                                                                            && x.LocEpsId == idEmpresa
                                                                            && x.LocIstId == idInstalacao);

                    if (local == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        resposta.Status = false;
                        return resposta;
                    }

                    resposta.Dados = local;
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

        public async Task<ResponseModel<List<Loc>>> ListarTodos(int? idEmpresa, int? idInstalacao)
        {
            ResponseModel<List<Loc>> resposta = new ResponseModel<List<Loc>>();
            //ResponseModel<Loc> resposta = new ResponseModel<Loc>();
            try
            {
                if (!string.IsNullOrEmpty(idEmpresa.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {

                    var locais = await _dbContext.Locs.Where(x => x.LocEpsId == idEmpresa
                                                                            && x.LocIstId == idInstalacao).ToListAsync();

                    if (locais == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        resposta.Status = false;
                        return resposta;
                    }
                    else
                    {
                        if (locais.Count <= 0)
                        {
                            resposta.Mensagem = "Nenhum Registro foi localizado";
                            resposta.Status = false;
                            return resposta;
                        }
                    }

                    resposta.Dados = locais;
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
