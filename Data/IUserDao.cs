using AutenticacaoComEmail.Data.Dtos;

namespace AutenticacaoComEmail.Data
{
    public interface IUserDao
    {
        Task IncluirAsync(LoginUserDto dto);
    }
}
