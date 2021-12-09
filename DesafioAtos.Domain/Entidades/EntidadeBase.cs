using System.Text.Json.Serialization;

namespace DesafioAtos.Domain.Entidades
{
    public abstract class EntidadeBase
    {
        [JsonIgnore]
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}