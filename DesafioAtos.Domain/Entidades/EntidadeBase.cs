namespace DesafioAtos.Domain.Entidades
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public DateTime? DataCriacao { get; set; }
    }
}