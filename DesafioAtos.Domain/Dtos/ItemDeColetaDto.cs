using DesafioAtos.Domain.Enum;

namespace DesafioAtos.Domain.Dtos
{
    public class ItemDeColetaDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime CreatedAt { get; set; }
        public CategoriaEnum Categoria { get; set; }
    }
}
