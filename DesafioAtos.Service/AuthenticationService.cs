
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entities;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.UnitOfWorks;
using DesafioAtos.Service.Exceptions;
using Microsoft.Extensions.Configuration;
using Np.Cryptography;

namespace DesafioAtos.Service
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICryptography _cryptography;
        private readonly IConfiguration _configuration;
        private readonly string _encryptKey;

        public UserAuthenticationService(IUnitOfWork unitOfWork, IMapper mapper, ICryptography cryptography, IConfiguration configuration)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._cryptography = cryptography;
            this._configuration = configuration;
            this._encryptKey = _configuration["cryptography:AppPasswordKey"];
        }

        public async Task<User> Login(CreateUserDto userDto)
        {
            var loginUser = _mapper.MapUserDtoToUser(userDto);
            User user = await _unitOfWork.Users.GetByUsername(loginUser.Username);
            ValidateUser(user, userDto);

            return user;
        }

        public async Task<User> CreateAccount(CreateUserDto userDto)
        {
            var userToBeCreated = _mapper.MapUserDtoToUser(userDto);
            var encryptedPassword = _cryptography.Encrypt(_encryptKey, userToBeCreated.Password);
            userToBeCreated.Password = encryptedPassword;

            return await _unitOfWork.ExecuteAsync<User>( async () =>
            {
                foreach (var roleId in userDto.RoleIds)
                {
                    var role = await _unitOfWork.Roles.GetById(roleId);
                    ValidateRole(role);
                    userToBeCreated.Roles.Add(role);
                }

                return await _unitOfWork.Users.Create(userToBeCreated);

            });

        }

        private void ValidateRole(Role role)
        {
            if (role == null)
            {
                throw new BadRequestException("Invalid Role Id.");
            }
        }

        private void ValidateUser(User user, CreateUserDto userDto)
        {
            var encryptedPassword = _cryptography.Encrypt(_encryptKey, userDto.Password);

            if (user == null || !user.Password.Equals(encryptedPassword))
            {
                throw new BadRequestException("Username os password invalid!");
            }
        }
    }
}
