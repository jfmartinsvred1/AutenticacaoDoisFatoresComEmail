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
            return Ok("Criado Com Sucesso");
        }
    }
}
