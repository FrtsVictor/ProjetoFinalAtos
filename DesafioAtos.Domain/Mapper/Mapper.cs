using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entities;

namespace DesafioAtos.Domain.Mapper
{
    public class Mapper : IMapper
    {
        public User MapUserDtoToUser(CreateUserDto loginDto) => new User()
        {
            Username = loginDto.Username,
            Password = loginDto.Password,
            Roles = new List<Role>()
        };
    }
}
