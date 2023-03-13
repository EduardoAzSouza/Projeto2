using projeto2.API.Model;

namespace projeto2.API.Repository
{
    public interface IEmpresaRepository
    {
        Task<Empresa> Adicionar(Empresa empresa);
        Task<Empresa> Atualizar(Empresa empresa, string nome);
        Task<List<Empresa>> BuscarTodasEmpresas();
        Task<Empresa> BuscarPorNome(string nome);
        Task<Empresa > BuscarPorCnpj(string cnpj);
        Task<bool> Apagar(int id);
    }
}
