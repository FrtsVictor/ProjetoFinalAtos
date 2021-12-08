using DesafioAtos.Domain.Enum;

namespace DesafioAtos.Domain.Entities
{
    public class ItemDeColeta : Base
    {
        public string Nome { get; set; }
        public CategoriaEnum Categoria { get; set; }
    }
}
