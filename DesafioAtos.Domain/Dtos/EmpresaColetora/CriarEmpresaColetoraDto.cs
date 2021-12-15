using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Dtos
{
    public class CriarEmpresaColetoraDto
    {
        public string Nome { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public List<CriarEnderecoDto> Enderecos { get; set; }
        public List<int> Categorias { get; set; }

        public CriarEmpresaColetoraDto()
        {
            this.Enderecos = new List<CriarEnderecoDto>();
            Categorias = new List<int>() { };
        }
    }
}
