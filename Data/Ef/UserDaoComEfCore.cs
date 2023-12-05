using AutenticacaoComEmail.Data.Dtos;
using AutenticacaoComEmail.Models;
using AutenticacaoComEmail.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AutenticacaoComEmail.Data.Ef
{
    public class UserDaoComEfCore : IUserDao
    {
        IMapper _mapper;
        UserManager<User> _userManager;
        IEmailDao _emailDao;

        public UserDaoComEfCore(IMapper mapper, UserManager<User> userManager, IEmailDao emailDao)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailDao = emailDao;
        }

        public async Task IncluirAsync(LoginUserDto dto)
        {
            User user = _mapper.Map<User>(dto);

            IdentityResult result = await _userManager.CreateAsync(user,dto.Password);

            if (!result.Succeeded) 
            {
                throw new ApplicationException("Error ao cadastrar o user");
            }
            var outlook = new Email("smtp.office365.com", "TestApiJfmartins@outlook.com", "Apiemail123!");
            outlook.SendEmail(dto.Email.ToString(), _emailDao.saveCod(dto.Email.ToString()));
        }
    }
}
