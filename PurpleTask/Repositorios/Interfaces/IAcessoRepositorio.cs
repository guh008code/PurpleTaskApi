using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface IAcessoRepositorio
    {
        Task<ResponseModel<AuthToken>> Login(Login login, string hash);

        Task<ResponseModel<Usr>> Atualizar(Usr usuario, string hash);

    }
}
