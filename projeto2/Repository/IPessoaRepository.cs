using projeto2.API.Data.ValueObjects;
using projeto2.API.Model;

namespace projeto2.API.Repository
{
    public interface IPessoaRepository
    {
        Task<PessoaVO> Adicionar(PessoaVO pessoaVo);
        Task<PessoaVO> Atualizar(PessoaVO pessoaVo);
        Task<IEnumerable<PessoaVO>> BuscarTodasPessoas();
        Task<PessoaVO> BuscarPorNome(string nome);
        Task<PessoaVO> BuscarPorID(long id);
        Task<bool> Apagar(long id);
    }
}
