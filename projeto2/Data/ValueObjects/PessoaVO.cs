using projeto2.API.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projeto2.API.Data.ValueObjects
{
    public class PessoaVO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string Usuario { get; set; }
        public Status Status { get; set; }
        public int EmpresaId { get; set; }
    }
}
