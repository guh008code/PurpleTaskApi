using Microsoft.EntityFrameworkCore;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Repositorios
{
    public class InventarioRepositorio : IInventarioRepositorio
    {
        private readonly PurpleMgmContext _dbContext;
        public InventarioRepositorio(PurpleMgmContext purpleTaskDBContex)
        {
            _dbContext = purpleTaskDBContex;
        }
        public async Task<ResponseModel<List<AvlItm>>> ListarTodos(int? idEmpresa, int? idInstalacao)
        {
            ResponseModel<List<AvlItm>> resposta = new ResponseModel<List<AvlItm>>();

            try
            {
                var inventarios = await _dbContext.AvlItms.Where(x => x.AvlItmEpsId == idEmpresa &&
                                                                 x.AvlItmIstId == idInstalacao).ToListAsync();

                //var inventarios = await _dbContext.AvlItms.FirstOrDefaultAsync(x => x.AvlItmIstId == idInstalacao);

                if (inventarios == null)
                {
                    resposta.Mensagem = "Nenhum Registro foi localizado";
                    return resposta;
                }

                resposta.Dados = inventarios;
                resposta.Mensagem = "Registros localizados";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<AvlItm>> BuscarPorId(int? id, int? idEmpresa, int? idInstalacao)
        {
            ResponseModel<AvlItm> resposta = new ResponseModel<AvlItm>();

            try
            {
                var inventario = await _dbContext.AvlItms.FirstOrDefaultAsync(x => x.AvlItmId == id 
                                                                            && x.AvlItmEpsId == idEmpresa
                                                                            && x.AvlItmIstId == idInstalacao);

                if (inventario == null)
                {
                    resposta.Mensagem = "Nenhum Registro foi localizado";
                    return resposta;
                }

                resposta.Dados = inventario;
                resposta.Mensagem = "Registro localizado";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AvlItm>> BuscarPlaqueta(int? AvlItmPlq, int? idEmpresa, int? idInstalacao)
        {
            ResponseModel<AvlItm> resposta = new ResponseModel<AvlItm>();

            try
            {
                var inventario = await _dbContext.AvlItms.FirstOrDefaultAsync(x => x.AvlItmPlq == AvlItmPlq
                                                                            && x.AvlItmEpsId == idEmpresa
                                                                            && x.AvlItmIstId == idInstalacao);

                if (inventario == null)
                {
                    resposta.Mensagem = "Nenhum Registro foi localizado";
                    return resposta;
                }

                resposta.Dados = inventario;
                resposta.Mensagem = "Registro localizado";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }


        public async Task<ResponseModel<AvlItm>> Adicionar(AvlItm inventario)
        {
            ResponseModel<AvlItm> resposta = new ResponseModel<AvlItm>();

            try
            {
                var inventarios = new AvlItm()
                {
                    AvlItmEpsId = inventario.AvlItmEpsId,
                    AvlItmLocId = inventario.AvlItmLocId,
                    AvlItmCecId = inventario.AvlItmCecId,
                    AvlItmSetId = inventario.AvlItmSetId,
                    AvlItmPlq = inventario.AvlItmPlq,
                    AvlItmPlqAnt = inventario.AvlItmPlqAnt,
                    AvlItmDes = inventario.AvlItmDes,
                    AvlItmComp = inventario.AvlItmComp,
                    AvlItmNumSer = inventario.AvlItmNumSer,
                    AvlItmCon = inventario.AvlItmCon,
                    AvlItmAnd = inventario.AvlItmAnd,
                    AvlItmSit = inventario.AvlItmSit,
                    AvlItmVlrAqs = inventario.AvlItmVlrAqs,
                    AvlItmSts = inventario.AvlItmSts,
                    AvlItmUsrIncId = inventario.AvlItmUsrIncId,
                    AvlItmUsrAltId = inventario.AvlItmUsrAltId,
                    AvlItmUsrExcId = inventario.AvlItmUsrExcId,
                    AvlItmDatInc = inventario.AvlItmDatInc,
                    AvlItmDatAlt = inventario.AvlItmDatAlt,
                    AvlItmDatExc = inventario.AvlItmDatExc,
                    AvlItmIstId = inventario.AvlItmIstId
                };

                _dbContext.Add(inventarios);
                await _dbContext.SaveChangesAsync();

                resposta.Dados = inventarios;
                resposta.Mensagem = "Inventário incluído com sucesso";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AvlItm>>> Atualizar(AvlItm inventarios)
        {
            ResponseModel<List<AvlItm>> resposta = new ResponseModel<List<AvlItm>>();

            try
            {
                var inventario = await _dbContext.AvlItms.FirstOrDefaultAsync(user => user.AvlItmId == inventarios.AvlItmId);

                if (inventario == null)
                {
                    resposta.Mensagem = "Nenhum inventário encontrado.";
                    return resposta;
                }


                inventario.AvlItmEpsId = inventarios.AvlItmEpsId;
                inventario.AvlItmLocId = inventarios.AvlItmLocId;
                inventario.AvlItmCecId = inventarios.AvlItmCecId;
                inventario.AvlItmSetId = inventarios.AvlItmSetId;
                inventario.AvlItmPlq = inventarios.AvlItmPlq;
                inventario.AvlItmPlqAnt = inventarios.AvlItmPlqAnt;
                inventario.AvlItmDes = inventarios.AvlItmDes;
                inventario.AvlItmComp = inventarios.AvlItmComp;
                inventario.AvlItmNumSer = inventarios.AvlItmNumSer;
                inventario.AvlItmCon = inventarios.AvlItmCon;
                inventario.AvlItmAnd = inventarios.AvlItmAnd;
                inventario.AvlItmSit = inventarios.AvlItmSit;
                inventario.AvlItmVlrAqs = inventarios.AvlItmVlrAqs;
                inventario.AvlItmSts = inventarios.AvlItmSts;
                inventario.AvlItmUsrIncId = inventarios.AvlItmUsrIncId;
                inventario.AvlItmUsrAltId = inventarios.AvlItmUsrAltId;
                inventario.AvlItmUsrExcId = inventarios.AvlItmUsrExcId;
                inventario.AvlItmDatInc = inventarios.AvlItmDatInc;
                inventario.AvlItmDatAlt = inventarios.AvlItmDatAlt;
                inventario.AvlItmDatExc = inventarios.AvlItmDatExc;
                inventario.AvlItmIstId = inventarios.AvlItmIstId;

                _dbContext.Update(inventario);
                await _dbContext.SaveChangesAsync();

                //resposta.Dados = await _dbContext.Usuarios.ToListAsync();
                resposta.Mensagem = "Inventário atualizado com sucesso";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AvlItm>>> Apagar(int? idInventario)
        {
            ResponseModel<List<AvlItm>> resposta = new ResponseModel<List<AvlItm>>();

            try
            {
                var inventarios = await _dbContext.AvlItms.FirstOrDefaultAsync(user => user.AvlItmId == idInventario);

                if (inventarios == null)
                {
                    resposta.Mensagem = "Nenhum inventário encontrado";
                    return resposta;
                }

                _dbContext.Remove(inventarios);
                await _dbContext.SaveChangesAsync();

                //resposta.Dados = await _dbContext.Usuarios.ToListAsync();
                resposta.Mensagem = "Inventário removido com sucesso";

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
