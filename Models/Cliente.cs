using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractéres. ", MinimumLength = 11)]
        public string? Cpf { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractéres. ", MinimumLength = 2)]
        public string? Nome { get; set; }
        [StringLength(9, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractéres. ", MinimumLength = 7)]
        public string? Rg { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataExpedicao { get; set; }
        public string? OrgaoExpedicao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Endereco? Endereco { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public char? Genero { get; set; }
        public string? EstadoCivil { get; set; }

    }
}