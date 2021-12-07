using System.Text.Json.Serialization;

namespace DesafioAtos.Domain.Entities;
public abstract class Base
{
    [JsonIgnore]
    public long Id { get; set; }
    public bool Status { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}