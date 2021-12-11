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

        public virtual EmpresaColeta? IdEmpresaColetaNavigation { get; set; }
    }
}
