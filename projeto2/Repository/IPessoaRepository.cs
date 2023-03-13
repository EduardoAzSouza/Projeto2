using projeto2.API.Data.ValueObjects;
using projeto2.API.Model;

namespace projeto2.API.Repository
{
    public interface IPessoaRepository
    {
        Task<PessoaVO> Adicionar(PessoaVO pessoaVo);
        Task<PessoaVO> Atualizar(PessoaVO pessoaVo, int id);
        Task<List<PessoaVO>> BuscarTodasPessoas();
        Task<PessoaVO> BuscarPorNome(string nome);
        Task<PessoaVO> BuscarPorID(int id);
        Task<bool> Apagar(int id);
    }
}
