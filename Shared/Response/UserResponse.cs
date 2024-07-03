using Shared.Response;

namespace Iss.Data.ViewModels.Response.Usuarios
{
    public class UserResponse
    {
        public Guid IdUser { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Status { get; set; }
        public AddressResponse Address { get; set; }
        // Outros campos relevantes para a resposta do cadastro de usuário
    }
}
