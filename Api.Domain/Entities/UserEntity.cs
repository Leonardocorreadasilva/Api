namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid AddressId { get; set; }
        // Propriedade de navegação para a entidade AddressEntity
    }
}
