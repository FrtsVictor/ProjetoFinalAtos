
namespace DesafioAtos.Domain.Dtos;

public class CreateUserDto
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public List<int>? RoleIds { get; set; }


}