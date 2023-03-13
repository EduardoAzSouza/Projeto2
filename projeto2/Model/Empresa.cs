using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using projeto2.API.Enums;

namespace projeto2.API.Model
{
    [Table("empresa")]
    public class Empresa
    {
        public int Id { get; set; }

        [Column("cnpj")]
        [Required]
        [StringLength(14)]
        public string Cnpj { get; set; }

        [Column("status")]
        public Status Status { get; set; }

        [Column("data_abertura")]
        public string DataAbertura { get; set; }

        [Column("nome_empresarial")]
        [Required]
        [StringLength(120)]
        public string NomeEmpresarial { get; set; }

        [Column("nome_fantasia")]
        [Required]
        [StringLength(120)]
        public string NomeFantasia { get; set; }

        [Column("cnae")]
        [Required]
        public List<string> CNAE { get; set; }

        [Column("Natureza_Juridica")]
        [Required]
        [StringLength(50)]
        public string NaturezaJuridica { get; set; }

        [ForeignKey("IdEndereço")]
        public Endereco Endereco { get; set; }

        [Column("telefone")]
        [StringLength(20)]
        public string Telefone { get; set; }

        [Column("capital")]
        public double Capital { get; set; }
    }
}
