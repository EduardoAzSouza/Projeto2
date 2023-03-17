using projeto2.API.Enums;

namespace projeto2.API.Data.ValueObjects
{
    public class PessoaViewVO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string Status { get; set; }
        public string Usuario { get; set; }
        public long? EmpresaId { get; set; }
    }
}
