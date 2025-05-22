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

        public async Task<ResponseModel<Set>> BuscarPorId(int? id, int? idEmpresa, int? idInstalacao)
        {
            ResponseModel<Set> resposta = new ResponseModel<Set>();
            try
            {
                if (!string.IsNullOrEmpty(id.ToString()) && !string.IsNullOrEmpty(idEmpresa.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {
                    var setor = await _dbContext.Sets.FirstOrDefaultAsync(x => x.SetId == id
                                                                            && x.SetEpsId == idEmpresa
                                                                            && x.SetIstId == idInstalacao);
                    if (setor == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        resposta.Status = false;
                        return resposta;
                    }

                    resposta.Dados = setor;
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

        public async Task<ResponseModel<List<Set>>> ListarTodos(int? idEmpresa, int? idLocal, int? idInstalacao)
        {

            ResponseModel<List<Set>> resposta = new ResponseModel<List<Set>>();
            //ResponseModel<Set> resposta = new ResponseModel<Set>();
            try
            {
                if (!string.IsNullOrEmpty(idEmpresa.ToString()) && !string.IsNullOrEmpty(idLocal.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {

                    var setores = await _dbContext.Sets.Where(x => x.SetEpsId == idEmpresa
                                                                            && x.SetLocId == idLocal
                                                                            && x.SetIstId == idInstalacao).ToListAsync();
                    if (setores == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        resposta.Status = false;
                        return resposta;
                    }
                    else
                    {
                        if (setores.Count <= 0)
                        {
                            resposta.Mensagem = "Nenhum Registro foi localizado";
                            resposta.Status = false;
                            return resposta;
                        }
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

        public async Task<ResponseModel<List<Set>>> ListarPorDescricao(Set setor)
        {

            ResponseModel<List<Set>> resposta = new ResponseModel<List<Set>>();
            //ResponseModel<Set> resposta = new ResponseModel<Set>();
            try
            {
                if (!string.IsNullOrEmpty(setor.SetEpsId.ToString()) && !string.IsNullOrEmpty(setor.SetLocId.ToString()) && !string.IsNullOrEmpty(setor.SetIstId.ToString()))
                {

                    var setores = await _dbContext.Sets.Where(x => x.SetEpsId == setor.SetEpsId
                                                                            && x.SetLocId == setor.SetLocId
                                                                            && x.SetIstId == setor.SetIstId
                                                                            && x.SetNom == setor.SetNom).ToListAsync();
                    if (setores == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        resposta.Status = false;
                        return resposta;
                    }
                    else
                    {
                        if (setores.Count <= 0)
                        {
                            resposta.Mensagem = "Nenhum Registro foi localizado";
                            resposta.Status = false;
                            return resposta;
                        }
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

        public async Task<ResponseModel<Set>> Adicionar(Set setor)
        {
            ResponseModel<Set> resposta = new ResponseModel<Set>();

            try
            {
                var setores = new Set()
                {
                    SetEpsId = setor.SetEpsId,
                    SetLocId = setor.SetLocId,
                    SetCod = setor.SetCod,
                    SetNom = setor.SetNom,
                    SetSts = setor.SetSts,
                    SetUsrIncId = setor.SetUsrIncId,
                    SetUsrAltId = setor.SetUsrAltId,
                    SetUsrExcId = (int?)null,
                    SetDatInc = DateTime.Now,
                    SetDatAlt = DateTime.Now,
                    SetDatExc = (DateTime?)null,
                    SetIstId = setor.SetIstId
                };

                _dbContext.Add(setores);
                await _dbContext.SaveChangesAsync();

                resposta.Dados = setores;
                resposta.Mensagem = "Setor incluído com sucesso";

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
