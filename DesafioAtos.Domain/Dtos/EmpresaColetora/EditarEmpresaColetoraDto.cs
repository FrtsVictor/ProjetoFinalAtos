namespace DesafioAtos.Domain.Dtos
{
    public class EditarEmpresaColetoraDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public bool Status { get; set; }
    }
}
