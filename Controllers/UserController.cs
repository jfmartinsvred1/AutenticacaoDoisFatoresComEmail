using AutenticacaoComEmail.Data;
using AutenticacaoComEmail.Data.Dtos;
using AutenticacaoComEmail.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutenticacaoComEmail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        IUserDao _userDao;

        public UserController(IUserDao userDao)
        {
            _userDao = userDao;
        }

        [HttpPost]
        public async Task<IActionResult> Include(LoginUserDto dto)
        {
            await _userDao.IncluirAsync(dto);
            var outlook = new Email("smtp.office365.com", "TestApiJfmartins@outlook.com", "Apiemail123!");
            outlook.SendEmail("jfmartinsvred1@gmail.com", "Confirmação De Email");
            return Ok("Criado Com Sucesso");
        }
    }
}
