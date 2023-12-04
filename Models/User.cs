using Microsoft.AspNetCore.Identity;

namespace AutenticacaoComEmail.Models
{
    public class User:IdentityUser
    {
        public bool Validator { get; set; }
        public User():base()
        {
            
        }
    }
}
