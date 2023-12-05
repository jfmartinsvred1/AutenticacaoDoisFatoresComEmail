using System.ComponentModel.DataAnnotations;

namespace AutenticacaoComEmail.Models
{
    public class ValidatorTemp
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
