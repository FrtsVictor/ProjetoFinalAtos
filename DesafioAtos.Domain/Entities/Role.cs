using System.Text.Json.Serialization;

namespace DesafioAtos.Domain.Entities
{
    public class Role : Base
    {
        public string? Name { get; set; }

        [JsonIgnore]
        public ICollection<User>? Users { get; set; }
    }
}