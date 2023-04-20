using System.ComponentModel.DataAnnotations;

namespace projeto2.API.Data.ValueObjects
{
    public class PessoaUpdateVO
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "O nome tem mais caracteres que o maximo permitido!")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "O tamanho maximo de Telefone é 11 Caracteres")]
        
        public string Telefone { get; set; }

        
        [MaxLength(50, ErrorMessage = "O Usuario tem mais caracteres que o maximo permitido!")]
        public string Usuario { get; set; }
    }
}
