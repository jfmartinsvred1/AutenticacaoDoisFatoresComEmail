using AutenticacaoComEmail.Data.Dtos;
using AutenticacaoComEmail.Models;
using AutoMapper;

namespace AutenticacaoComEmail.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<LoginUserDto,User>();
        }
    }
}
