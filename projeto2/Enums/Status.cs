using System.ComponentModel;

namespace projeto2.API.Enums
{
    public enum Status : int
    {
        [Description("Inativo")]
        Inativo = 1,
        [Description("Pendente")]
        Pendente = 2,
        [Description("Ativo")]
        Ativo = 3,

    }
}
