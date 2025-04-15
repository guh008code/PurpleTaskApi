namespace PurpleTask.Models
{
    public class AuthToken
    {
        public string AcessToken { get; set; }
        public string Nome { get; set; }
        public string Instalacao { get; set; }

        public string Email { get; set; }

        public string IdUser { get; set; }
        public string IdEmpresa { get; set; }

        public string IdPerfil { get; set; }
    }
}
