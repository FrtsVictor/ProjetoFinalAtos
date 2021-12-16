namespace DesafioAtos.Domain.Dtos.Token
{
    public class CreateTokenDto
    {
        public string Identificador { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int Id { get; set; }
    }
}