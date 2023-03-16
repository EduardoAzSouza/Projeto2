using projeto2.API.Enums;
using projeto2.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto2.API.Model
{
    [Table("Pessoa")]
    public class Pessoa : BaseEntity
    {

        [Column("Nome")]
        [Required]
        [StringLength(80)]
        public string Nome { get; set; }

        [Column("documento")]
        [Required]
        [StringLength(14)]
        public string Documento { get; set; }

        [Column("telefone")]
        [StringLength(20)]
        public string Telefone { get; set; }

        [Column("usuario")]
        [Required]
        [StringLength(50)]
        public string Usuario { get; set; }

        [Column("status")]
        public Status Status { get; set; }

        [Column("EmpresaId")]
        public long? EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }

    }
}
