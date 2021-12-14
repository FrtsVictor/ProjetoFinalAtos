using System.Text.Json.Serialization;

namespace DesafioAtos.Domain.Dtos
{
    public class CategoriaDto
    {
        public int IdCategoria { get; set; }
        [JsonIgnore]
        public int IdLigacao { get; set; }
    }
}