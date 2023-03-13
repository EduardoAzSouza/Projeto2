using projeto2.API.Model;
using System.Threading.Tasks;

namespace projeto2.API.Repository
{
    public interface IPessoaRepository
    {
        Task<Pessoa> Adicionar(Pessoa pessoa);
        Task<Pessoa> Atualizar(Pessoa pessoa, int id);
        Task<List<Pessoa>> BuscarTodasPessoas();
        Task<Pessoa> BuscarPorNome(string nome);
        Task<Pessoa> BuscarPorID(int id);
        Task<bool> Apagar(int id);
    }
}
