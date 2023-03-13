using Microsoft.EntityFrameworkCore;
using projeto2.API.Model;
using projeto2.API.Model.context;

namespace projeto2.API.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly MySQLContext _dbContext;

        public EmpresaRepository(MySQLContext mySQLContext)
        {
            _dbContext = mySQLContext;
        }

        public async Task<Empresa> BuscarPorNome(string nome)
        {
            return await _dbContext.Empresa.FirstOrDefaultAsync(x => x.NomeFantasia == nome);
        }

        public async Task<Empresa> BuscarPorCnpj(string cnpj)
        {
            return await _dbContext.Empresa.FirstOrDefaultAsync(x => x.Cnpj == cnpj);
        }

        public async Task<List<Empresa>> BuscarTodasEmpresas()
        {
            return await _dbContext.Empresa.ToListAsync();
        }
        public async Task<Empresa> Adicionar(Empresa empresa)
        {
            await _dbContext.Empresa.AddAsync(empresa);
            await _dbContext.SaveChangesAsync();

            return empresa;
        }

        public async Task<Empresa> Atualizar(Empresa empresa, string nome)
        {
            Empresa empresaPorNome = await BuscarPorNome(nome);
            if (empresaPorNome == null)
            {
                throw new Exception($"Empresa para o nome:{nome} não foi encontrada.");
            }

            empresaPorNome.Cnpj = empresa.Cnpj;
            empresaPorNome.DataAbertura = empresa.DataAbertura;
            empresaPorNome.NomeEmpresarial = empresa.NomeEmpresarial;
            empresaPorNome.NomeFantasia = empresa.NomeFantasia;
            empresaPorNome.CNAE = empresa.CNAE;
            empresaPorNome.NaturezaJuridica = empresa.NaturezaJuridica;
            empresaPorNome.Telefone = empresa.Telefone;
            empresaPorNome.Capital = empresa.Capital;


            _dbContext.Empresa.Update(empresaPorNome);
            await _dbContext.SaveChangesAsync();

            return empresaPorNome;
        }

        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

    }
}
