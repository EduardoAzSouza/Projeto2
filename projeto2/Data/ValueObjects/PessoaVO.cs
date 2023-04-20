using System.ComponentModel.DataAnnotations;

namespace projeto2.API.Data.ValueObjects
{
    public class PessoaVO
    {

        [Required]
        [MaxLength(80, ErrorMessage ="O nome tem mais caracteres que o maximo permitido!")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "O tamanho maximo do CPF é 11 Caracteres")]
        [MinLength(11, ErrorMessage = "O tamanho minimo do CPF é 11 Caracteres")]
        public string Documento { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "O tamanho maximo de Telefone é 11 Caracteres")]
        
        public string Telefone { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "O Usuario tem mais caracteres que o maximo permitido!")]
        public string Usuario { get; set; }
    }
}
