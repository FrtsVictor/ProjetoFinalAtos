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

        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<EnderecoDto> Endereco { get; set; }
        //criar lista Enum
        public List<Categoria> Categoria { get; set; }

        public CriarEmpresaColetoraDto()
        {
            this.Endereco = new List<EnderecoDto>();
            this.Categoria = new List<Categoria>();
        }
    }
}
