using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Dtos
{
    public class ColetaDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public long EmpresaColetaId { get; set; }
        public EmpresaColetoraDto EmpresaColetora { get; set; }
        public List<ItemDeColeta> ItensDeColeta { get; set; }
    }
}
