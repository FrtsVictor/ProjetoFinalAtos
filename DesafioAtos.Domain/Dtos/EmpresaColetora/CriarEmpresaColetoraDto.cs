using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Dtos
{
    public class CriarEmpresaColetoraDto
    {
        public string Senha { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<EnderecoDto> Endereco { get; set; }
        public List<int> Categorias { get; set; }

        public CriarEmpresaColetoraDto()
        {
            this.Endereco = new List<EnderecoDto>();
            Categorias = new List<int>() { };
        }
    }
}
