using AutenticacaoComEmail.Models;

namespace AutenticacaoComEmail.Data.Ef
{
    public class EmailDaoEfCore : IEmailDao
    {
        AppDbContext _appDbContext;

        public EmailDaoEfCore(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string saveCod(string email)
        {
            string code = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);
            ValidatorTemp v = new ValidatorTemp();
            v.Email = email;
            v.Code = code;

            _appDbContext.ValidatorTemps.Add(v);
            _appDbContext.SaveChanges();
            return code;
        }
    }
}
