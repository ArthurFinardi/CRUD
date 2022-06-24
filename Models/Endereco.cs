using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Cep { get; set; }
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractéres. ", MinimumLength = 2)]
        public string? Logradouro { get; set; }
        [MaxLength(10)]
        [MinLength(1)]
        public string? Numero { get; set; }
        [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractéres. ", MinimumLength = 2)]
        public string? Complemento { get; set; }

        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractéres. ", MinimumLength = 2)]
        public string? Bairro { get; set; }

        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractéres. ", MinimumLength = 2)]
        public string? Cidade { get; set; }
        [StringLength(2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractéres. ", MinimumLength = 1)]
        public string? Uf { get; set; }
    }
}
