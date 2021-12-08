using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entities;

namespace DesafioAtos.Service
{
    public interface IUserAuthenticationService
    {
        Task<User> Login(CreateUserDto createUserDto);
        Task<User> CreateAccount(CreateUserDto createUserDto);
    }
}