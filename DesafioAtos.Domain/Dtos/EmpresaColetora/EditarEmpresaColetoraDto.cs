using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Dtos
{
    public class EditarEmpresaColetoraDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

        public List<EnderecoDto> Endereco { get; set; }
        public List<Categoria> Categoria { get; set; }
    }
}
