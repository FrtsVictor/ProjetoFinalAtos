using DesafioAtos.Domain.Entities;
using DesafioAtos.Domain.Enum;

namespace DesafioAtos.Domain.Dtos
{
    public class Categoria : Base
    {
        public CategoriaEnum Categorias { get; set; }
    }
}
