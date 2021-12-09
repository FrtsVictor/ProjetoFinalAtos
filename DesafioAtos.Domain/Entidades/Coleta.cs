namespace DesafioAtos.Domain.Entidades
{
    public class Coleta : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<ItemDeColeta> ItensDeColeta { get; set; }
        public EmpresaColetora EmpresaColetora { get; set; }
    }
}
