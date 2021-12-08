namespace DesafioAtos.Domain.Entities;

public class User : Base
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public ICollection<Role>? Roles { get; set; }
}