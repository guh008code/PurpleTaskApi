using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Repositorios
{
    public class SetorRepositorio : ISetorRepositorio
    {
        private readonly PurpleMgmContext _dbContext;
        public SetorRepositorio(PurpleMgmContext purpleTaskDBContex)
        {
            _dbContext = purpleTaskDBContex;
        }

        public async Task<ResponseModel<Set>> BuscarPorId(int id, int idEmpresa, int idInstalacao)
        {
            ResponseModel<Set> resposta = new ResponseModel<Set>();
            try
            {
                if (!string.IsNullOrEmpty(id.ToString()) && !string.IsNullOrEmpty(idEmpresa.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {
                    var usuarios = await _dbContext.Sets.FirstOrDefaultAsync(x => x.SetId == id
                                                                            && x.SetEpsId == idEmpresa
                                                                            && x.SetIstId == idInstalacao);
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

        public async Task<ResponseModel<List<Set>>> ListarTodos(int idEmpresa, int idLocal, int idCentroDeCusto, int idInstalacao)
        {

            ResponseModel<List<Set>> resposta = new ResponseModel<List<Set>>();
            //ResponseModel<Set> resposta = new ResponseModel<Set>();
            try
            {
                if (!string.IsNullOrEmpty(idEmpresa.ToString()) && !string.IsNullOrEmpty(idLocal.ToString()) && !string.IsNullOrEmpty(idCentroDeCusto.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {

                    var setores = await _dbContext.Sets.Where(x => x.SetEpsId == idEmpresa
                                                                            && x.SetLocId == idLocal
                                                                            && x.SetCecId == idCentroDeCusto
                                                                            && x.SetIstId == idInstalacao).ToListAsync();
                    if (setores == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        return resposta;
                    }

                    resposta.Dados = setores;
                    resposta.Mensagem = "Registro localizado";

                }
                else if (!string.IsNullOrEmpty(idEmpresa.ToString()) && !string.IsNullOrEmpty(idLocal.ToString()) && string.IsNullOrEmpty(idCentroDeCusto.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {
                    var setores = await _dbContext.Sets.Where(x => x.SetEpsId == idEmpresa
                                                                            && x.SetLocId == idLocal
                                                                            && x.SetIstId == idInstalacao).ToListAsync();
                    if (setores == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        return resposta;
                    }

                    resposta.Dados = setores;
                    resposta.Mensagem = "Registro localizado";
                }
                else if (!string.IsNullOrEmpty(idEmpresa.ToString()) && string.IsNullOrEmpty(idLocal.ToString()) && string.IsNullOrEmpty(idCentroDeCusto.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {
                    var setores = await _dbContext.Sets.Where(x => x.SetEpsId == idEmpresa
                                                              && x.SetIstId == idInstalacao).ToListAsync();
                    if (setores == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        return resposta;
                    }

                    resposta.Dados = setores;
                    resposta.Mensagem = "Registro localizado";
                }
                else if (string.IsNullOrEmpty(idEmpresa.ToString()) && string.IsNullOrEmpty(idLocal.ToString()) && string.IsNullOrEmpty(idCentroDeCusto.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {
                    var setores = await _dbContext.Sets.Where(x => x.SetIstId == idInstalacao).ToListAsync();
                    if (setores == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        return resposta;
                    }

                    resposta.Dados = setores;
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
