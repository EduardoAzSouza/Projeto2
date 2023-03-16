using projeto2.API.Data.ValueObjects;
using projeto2.API.Model;

namespace projeto2.API.Repository
{
    public interface IEmpresaRepository
    {
        Task<EmpresaVO> Adicionar(EmpresaVO empresaVo);
        Task<EmpresaUpdateVO> Atualizar(EmpresaUpdateVO empresa);
        Task<List<Empresa>> BuscarTodasEmpresas();
        Task<Empresa> BuscarPorNome(string nome);
        Task<Empresa> BuscarPorCnpj(string cnpj);
        Task<bool> Apagar(long id);
    }
}
