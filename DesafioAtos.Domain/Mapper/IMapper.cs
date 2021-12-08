using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entities;


namespace DesafioAtos.Domain.Mapper;

public interface IMapper
{
    User MapUserDtoToUser(CreateUserDto userDto);
}