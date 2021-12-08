namespace DesafioAtos.Domain.Dtos
{
    public class EmpresaColetoraDto
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }


        public List<Endereco> Endereco { get; set; }
        public List<Categoria> Categoria { get; set; }
    }
}
