using projeto2.API.Data.ValueObjects;

namespace projeto2.API.Repository
{
    public interface IEmpresaRepository
    {
        Task<EmpresaVO> Adicionar(EmpresaVO empresaVo);
        Task<EmpresaVO> Atualizar(EmpresaVO empresaVo);
        Task<List<EmpresaVO>> BuscarTodasEmpresas();
        Task<EmpresaVO> BuscarPorNome(string nome);
        Task<EmpresaVO> BuscarPorCnpj(string cnpj);
        Task<bool> Apagar(long id);
    }
}
