namespace DesafioAtos.Domain.Entidades
{
    public partial class Endereco : EntidadeBase
    {
        public string Numero { get; set; } = null!;
        public string? Complemento { get; set; }
        public string Rua { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public int? IdEmpresaColeta { get; set; }
        public bool Status { get; set; } = true;
        public DateTime? DataCriacao { get; set; } = DateTime.Now;

        public virtual EmpresaColetora? IdEmpresaColetaNavigation { get; set; }
    }
}
