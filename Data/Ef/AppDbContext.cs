using AutenticacaoComEmail.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutenticacaoComEmail.Data.Ef
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts):base(opts)
        {
            
        }
        public DbSet<ValidatorModel> ValidatorModels { get; set; }
    }
}
