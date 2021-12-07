
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entities;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.Repository.Interfaces;
using DesafioAtos.Infra.UnitfWork;
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

        public async Task<User> Login(UserDto userDto)
        {
            var loginUser = _mapper.MapUserDtoToUser(userDto);
            User user = await _unitOfWork.Users.GetByUsername(userDto.Username);
            var ecryptedPassword = _cryptography.Encrypt(_encryptKey, userDto.Password);

            if(user == null || !user.Password.Equals(ecryptedPassword) )
            {
                throw new Exception("Usuario invalido");
            }

            return user;
        }

        public async Task<User> CreateAccount(UserDto userDto)
        {
            var userToBeCreated = _mapper.MapUserDtoToUser(userDto);
            userToBeCreated.Password = _cryptography.Encrypt(_encryptKey, userToBeCreated.Password);
            var userCreated = await _unitOfWork.Users.Create(userToBeCreated);
            return userCreated;
        }
    }
}
