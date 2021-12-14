namespace DesafioAtos.Domain.Entidades
{
    public class CategoriaUsuario : EntidadeBase
    {
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }


        public virtual Usuario Usuario { get; set; } // Reference navigation property.
        public virtual Categoria Categoria { get; set; } // Reference navigation property.
    }
}