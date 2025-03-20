﻿using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface IAcessoRepositorio
    {
        Task<ResponseModel<AuthToken>> Login(string email, string senha);

    }
}
