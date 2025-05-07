using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface IAcessoRepositorio
    {
        Task<ResponseModel<AuthToken>> Login(Login login);

        Task<ResponseModel<Usr>> Atualizar(Usr usuario);

    }
}
