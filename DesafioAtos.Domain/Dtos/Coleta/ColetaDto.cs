using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Domain.Dtos
{
    public class ColetaDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string? ItemDeColeta { get; set; }
        public string? Observacao { get; set; }
        public bool Status { get; set; }
        public string EmpresaColetaId { get; set; }
        public string Categoria { get; set; }

    }
}
