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
        SignInManager<User> _signInManager;
        AppDbContext _appDbContext;

        public UserDaoComEfCore(IMapper mapper, UserManager<User> userManager, IEmailDao emailDao, SignInManager<User> signInManager, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailDao = emailDao;
            _signInManager = signInManager;
            _appDbContext = appDbContext;
        }

        public async Task IncluirAsync(CreateUserDto dto)
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
        public async Task LogarAsync(LoginUserDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuario nao autenticado");
            }

        }
        public void AutenticaUserCod(string codigo, string email)
        {
            var cod = _appDbContext.ValidatorTemps.FirstOrDefault(c=>c.Code==codigo && c.Email==email);
            if (cod != null)
            {
                var user = _appDbContext.Users.FirstOrDefault(e => e.Email == email);
                user.Validator = true;

                _appDbContext.Users.Update(user);
                _appDbContext.SaveChanges();

                _appDbContext.ValidatorTemps.Remove(cod);
                _appDbContext.SaveChanges();

            }
            else
            {
                throw new ApplicationException("Erro ao autenticar");
            }
        }
    }
}
