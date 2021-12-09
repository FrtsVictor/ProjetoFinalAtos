using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Dtos
{
    public class CriarEmpresaColetoraDto
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
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
