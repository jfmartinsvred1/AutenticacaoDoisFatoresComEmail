using System.ComponentModel.DataAnnotations;

namespace AutenticacaoComEmail.Data.Dtos
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
