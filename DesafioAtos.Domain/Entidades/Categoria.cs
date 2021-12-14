namespace DesafioAtos.Domain.Entidades
{
    public partial class Categoria : EntidadeBase
    {
        public Categoria()
        {
            //CategoriaUsuario = new HashSet<CategoriaUsuario>();
        }
     
        public string Nome { get; set; } = null!;

        //public virtual ICollection<CategoriaUsuario> CategoriaUsuario { get; set; }
    }
}
