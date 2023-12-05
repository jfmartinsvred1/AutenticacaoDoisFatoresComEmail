using AutenticacaoComEmail.Data.Dtos;

namespace AutenticacaoComEmail.Data
{
    public interface IUserDao
    {
        Task IncluirAsync(CreateUserDto dto);
        void AutenticaUserCod(string codigo, string email);
    }
}
