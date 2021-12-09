namespace DesafioAtos.Domain.Dtos
{
    public class CreateEmpresaColetoraDto
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Endereco> Endereco { get; set; }
        //criar lista Enum
        public List<Categoria> Categoria { get; set; }

        public CreateEmpresaColetoraDto()
        {
            this.Endereco = new List<Endereco>();
            this.Categoria = new List<Categoria>();
        }
    }
}
