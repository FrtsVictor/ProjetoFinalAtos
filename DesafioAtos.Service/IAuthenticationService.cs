using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entities;

namespace DesafioAtos.Service;

public interface IUserAuthenticationService
{
    Task<User> Login(CreateUserDto luserto);
    Task<User> CreateAccount(CreateUserDto createUserDto);
}
