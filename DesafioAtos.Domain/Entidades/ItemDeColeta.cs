using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Domain.Entidades
{
    public class ItemDeColeta : EntidadeBase
    {
        public string Nome { get; set; }
        public ECategoria Categoria { get; set; }
    }
}
