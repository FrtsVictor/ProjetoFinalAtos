using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Domain.Dtos
{
    public class CreateItemDeColetaDto
    {
        public string Nome { get; set; }
        public DateTime CreatedAt { get; set; }
        public ECategoria Categoria { get; set; }
    }
}
