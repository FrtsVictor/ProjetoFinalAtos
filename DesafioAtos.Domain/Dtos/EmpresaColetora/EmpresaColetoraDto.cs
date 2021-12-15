using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Dtos
{
    public class EmpresaColetoraDto
    {

        public string Senha { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;

        public bool Status { get; set; }


        public List<EnderecoDto> Endereco { get; set; } = new();
        public List<Categoria> Categorias { get; set; } = new();


    }
}
