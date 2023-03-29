using projeto2.API.Data.ValueObjects;
using projeto2.API.Model;

namespace projeto2.API.Repository
{
    public interface IPessoaRepository
    {
        Task<PessoaVO> Adicionar(PessoaVO pessoaVo);
        Task<PessoaUpdateVO> Atualizar(PessoaUpdateVO pessoa);
        Task<IEnumerable<PessoaViewVO>> BuscarTodasPessoas();
        Task<List<PessoaViewVO>> BuscarPorNome(string nome);
        Task<PessoaViewVO> BuscarPorID(long id);
        Task<bool> Apagar(long id);
        Task<bool> Atualizar_Status(long id);
        Task<PessoaViewVO> vincular_empresa(long pessoa_id, long empresa_id);
    }
}
