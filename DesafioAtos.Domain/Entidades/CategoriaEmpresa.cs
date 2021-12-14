namespace DesafioAtos.Domain.Entidades
{
    public class CategoriaEmpresa : EntidadeBase
    {
        public int IdEmpresaColetora { get; set; }
        public int IdCategoria { get; set; }


        public virtual EmpresaColetora EmpresaColetora { get; set; } = null!;
        public virtual Categoria Categoria { get; set; } = null!;
    }
}