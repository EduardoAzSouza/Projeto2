using projeto2.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace projeto2.API.Data.ValueObjects
{
    public class EmpresaUpdateVO
    {
        [Required]
        public long Id { get; set; }

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
