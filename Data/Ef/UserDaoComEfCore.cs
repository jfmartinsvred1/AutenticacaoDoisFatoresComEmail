using AutenticacaoComEmail.Data.Dtos;
using AutenticacaoComEmail.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AutenticacaoComEmail.Data.Ef
{
    public class UserDaoComEfCore : IUserDao
    {
        IMapper _mapper;
        UserManager<User> _userManager;

        public UserDaoComEfCore(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task IncluirAsync(LoginUserDto dto)
        {
            User user = _mapper.Map<User>(dto);

            IdentityResult result = await _userManager.CreateAsync(user,dto.Password);

            if (!result.Succeeded) 
            {
                throw new ApplicationException("Error ao cadastrar o user");
            }
        }
    }
}
