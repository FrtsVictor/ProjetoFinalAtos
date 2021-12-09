using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Domain.Dtos
{
    public class ItemDeColetaDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime CreatedAt { get; set; }
        public ECategoria Categoria { get; set; }
    }
}
