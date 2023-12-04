using System.ComponentModel.DataAnnotations;

namespace AutenticacaoComEmail.Models
{
    public class ValidatorModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Code { get; set; }


    }
}
