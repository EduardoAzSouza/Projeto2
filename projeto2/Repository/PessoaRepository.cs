using Microsoft.EntityFrameworkCore;
using projeto2.API.Model;
using projeto2.API.Model.context;

namespace projeto2.API.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly MySQLContext _dbContext;
        public PessoaRepository(MySQLContext mySQLContext)
        {
            _dbContext = mySQLContext;
        }
        public async Task<Pessoa> BuscarPorID(int id)
        {
            return await _dbContext.Pessoa.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pessoa> BuscarPorNome(string nome)
        {
            return await _dbContext.Pessoa.FirstOrDefaultAsync(p => p.Nome == nome);
        }

        public async Task<List<Pessoa>> BuscarTodasPessoas()
        {
            return  await _dbContext.Pessoa.ToListAsync();
        }

        public async Task<Pessoa> Adicionar(Pessoa pessoa)
        {
            await _dbContext.Pessoa.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();

            return pessoa;
        }

        public async Task<Pessoa> Atualizar(Pessoa pessoa, int id)
        {
            Pessoa pessoaPorId = await BuscarPorID(id);
            if(pessoaPorId == null)
            {
                throw new Exception($"Usuario para o ID:{id} não foi encontrado.");
            }

            pessoaPorId.Nome = pessoa.Nome;
            pessoaPorId.Documento = pessoa.Documento;
            pessoaPorId.Telefone = pessoa.Telefone;
            pessoaPorId.Usuario = pessoa.Usuario;
            pessoaPorId.EmpresaId = pessoa.EmpresaId;

            _dbContext.Pessoa.Update(pessoaPorId);
            await _dbContext.SaveChangesAsync();

            return pessoaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Pessoa pessoaPorId = await BuscarPorID(id);
            if (pessoaPorId == null)
            {
                throw new Exception($"Usuario para o ID:{id} não foi encontrado.");
            }

            _dbContext.Pessoa.Remove(pessoaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        } 
    }
}
