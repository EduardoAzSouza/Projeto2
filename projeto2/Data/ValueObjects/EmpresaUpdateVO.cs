using projeto2.API.Enums;

namespace projeto2.API.Data.ValueObjects
{
    public class EmpresaUpdateVO
    {
        public long Id { get; set; }
        public string NomeEmpresarial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNAE { get; set; }
        public string NaturezaJuridica { get; set; }
        public EnderecoVO Endereco { get; set; }
        public string Telefone { get; set; }
        public double Capital { get; set; }
    }
}
