﻿using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entities;

namespace DesafioAtos.Service;

public interface IUserAuthenticationService
{
    Task<User> Login(UserDto luserto);
    Task<User> CreateAccount(UserDto userDto);
}
