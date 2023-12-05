using Microsoft.AspNetCore.Identity;

namespace AutenticacaoComEmail.Models
{
    public class User:IdentityUser
    {
        public bool Validator { get; set; }=false;
        public User():base()
        {
            
        }
    }
}
