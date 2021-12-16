namespace DesafioAtos.Domain.Dtos
{
    public class EnderecoDto
    {
        public long Id { get; set; }
        public string Numero { get; set; } = null!;
        public string? Complemento { get; set; }
        public string Rua { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Bairro { get; set; } = null!;
    }
}