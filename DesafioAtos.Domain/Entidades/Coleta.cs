using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Domain.Entidades
{
    public class Coleta : EntidadeBase
    {
        public string? Nome { get; set; }
        public string? ItemDeColeta { get; set; }
        public string? Observacao { get; set; }
        public ECategoria Categoria { get; set; }
        public EmpresaColetora EmpresaColetora { get; set; }
    }
}
