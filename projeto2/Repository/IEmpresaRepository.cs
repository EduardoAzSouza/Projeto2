using projeto2.API.Data.ValueObjects;
using projeto2.API.Model;

namespace projeto2.API.Repository
{
    public interface IEmpresaRepository
    {
        Task<EmpresaVO> Adicionar(EmpresaVO empresaVo);
        Task<EmpresaUpdateVO> Atualizar(EmpresaUpdateVO empresa);
        Task<List<EmpresaViewVO>> BuscarTodasEmpresas();
        Task<List<EmpresaViewVO>> BuscarPorNome(string nome);
        Task<EmpresaViewVO> BuscarPorId(long id);
        Task<EmpresaViewVO> BuscarPorCnpj(string cnpj);
        Task<bool> Apagar(long id);
        Task<bool> Atualizar_Status(long id);
        Task<List<PessoaVO>> TodasPessoasEmpresa(long id);
    }
}
