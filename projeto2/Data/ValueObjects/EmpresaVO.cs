using projeto2.API.Model;
using System.ComponentModel.DataAnnotations;

namespace projeto2.API.Data.ValueObjects
{
    public class EmpresaVO
    {
        [Required]
        [MaxLength(14, ErrorMessage = "O CNPJ tem o tamanho maximo de 14 caracteres!")]
        [MinLength(14, ErrorMessage = "O CNPJ tem o tamanho minimo de 14 caracteres!")]
        public string Cnpj { get; set; }

        [MaxLength(10, ErrorMessage = "a Data de Abertura tem mais digitos que o maximo permitido!")]
        public string DataAbertura { get; set; }

        [Required]
        [MaxLength(120, ErrorMessage = "O nome empresarial tem mais caracteres que o maximo permitido!")]
        public string NomeEmpresarial { get; set; }

        
        [MaxLength(120, ErrorMessage = "O nome fantasia tem mais caracteres que o maximo permitido!")]
        public string NomeFantasia { get; set; }
        public string CNAE { get; set; }

        [MaxLength(50, ErrorMessage = "Natureza Juridica tem mais caracteres que o maximo permitido!")]
        public string NaturezaJuridica { get; set; }
        public EnderecoVO Endereco { get; set; }

        [MaxLength(11, ErrorMessage = "O tamanho maximo de Telefone é 11 Caracteres")]
        public string Telefone { get; set; }
        public double Capital { get; set; }
    }
}
