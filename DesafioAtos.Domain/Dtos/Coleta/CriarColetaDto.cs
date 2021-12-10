using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Domain.Dtos
{
    public class CriarColetaDto
    {
        public string Nome { get; set; }
        public string? ItemDeColeta { get; set; }
        public string? Observacao { get; set; }
        public ECategoria Categoria { get; set; }
        public long EmpresaColetaId { get; set; }


    }
}

