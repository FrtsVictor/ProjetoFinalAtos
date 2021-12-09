using DesafioAtos.Domain.Enum;

namespace DesafioAtos.Domain.Dtos
{
    public class CreateItemDeColetaDto
    {
        public string Nome { get; set; }
        public DateTime CreatedAt { get; set; }
        public CategoriaEnum Categoria { get; set; }
    }
}
