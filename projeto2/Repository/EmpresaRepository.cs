using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projeto2.API.Data.ValueObjects;
using projeto2.API.Enums;
using projeto2.API.Model;
using projeto2.API.Model.context;

namespace projeto2.API.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public EmpresaRepository(MySQLContext mySQLContext, IMapper mapper)
        {
            _context = mySQLContext;
            _mapper = mapper;
        }

        public async Task<List<EmpresaViewVO>> BuscarPorNome(string nome)
        {
            List<Empresa> empresa = await _context.Empresas.Where(p => p.NomeFantasia.Contains(nome))
                .Include(e => e.Endereco).ToListAsync();
            return _mapper.Map<List<EmpresaViewVO>>(empresa);
        }

        public async Task<EmpresaViewVO> BuscarPorCnpj(string cnpj)
        {
            Empresa empresa = await _context.Empresas.Where(p => p.Cnpj == cnpj)
                .Include(e => e.Endereco).FirstOrDefaultAsync();
            return _mapper.Map<EmpresaViewVO>(empresa);
        }

        public async Task<List<EmpresaViewVO>> BuscarTodasEmpresas()
        {
            List<Empresa> empresa = await _context.Empresas.Include(e => e.Endereco).ToListAsync();
            return _mapper.Map<List<EmpresaViewVO>>(empresa);
        }
        public async Task<EmpresaVO> Adicionar(EmpresaVO vo)
        {
            Empresa empresa = _mapper.Map<Empresa>(vo);
            var verficaCnpj = await _context.Empresas
                .Where(p => p.Cnpj == empresa.Cnpj)
                .FirstOrDefaultAsync();
            if (vo.Cnpj == null || vo.DataAbertura == null || vo.NomeEmpresarial == null || vo.NomeFantasia == null || vo.NaturezaJuridica == null || vo.Telefone == null ||
                vo.Cnpj == "string" || vo.DataAbertura == "string" || vo.NomeEmpresarial == "string" || vo.NomeFantasia == "string" || vo.NaturezaJuridica == "string" || vo.Telefone == "string" || vo.Capital == 0 ||
                vo.Cnpj.Trim() == "" || vo.DataAbertura.Trim() == "" || vo.NomeEmpresarial.Trim() == "" || vo.NomeFantasia.Trim() == "" || vo.NaturezaJuridica.Trim() == "" || vo.Telefone.Trim() == "" || vo.Endereco == null)
            {
                empresa.Status = Enums.Status.Pendente;
            }
            else
            {
                empresa.Status = Enums.Status.Ativo;
            }
            if(verficaCnpj == null) 
            {
                _context.Empresas.Add(empresa);
                await _context.SaveChangesAsync();
                return _mapper.Map<EmpresaVO>(empresa);
            }
            else 
            {
                empresa = null;
                return _mapper.Map<EmpresaVO>(empresa);
            }
        }

        public async Task<EmpresaUpdateVO> Atualizar(EmpresaUpdateVO vo)
        {
            
            Empresa empresa = _mapper.Map<Empresa>(vo);
            Empresa empresaDB = await _context.Empresas
                .AsNoTracking()
                .Where(c => c.Id == empresa.Id)
                .FirstOrDefaultAsync();

            empresa.Cnpj = empresaDB.Cnpj;
            empresa.DataAbertura = empresaDB.DataAbertura;

            if (vo.NomeEmpresarial == null || vo.NomeFantasia == null || vo.NaturezaJuridica == null || vo.Telefone == null ||vo.CNAE == null ||
                vo.NomeEmpresarial == "string" || vo.NomeFantasia == "string" || vo.NaturezaJuridica == "string" || vo.Telefone == "string" || vo.CNAE == "string" || vo.Capital == 0 ||
                vo.NomeEmpresarial.Trim() == "" || vo.NomeFantasia.Trim() == "" || vo.NaturezaJuridica.Trim() == "" || vo.Telefone.Trim() == "" || vo.CNAE.Trim() == "" || vo.Endereco == null)
            {
                empresa.Status = Enums.Status.Pendente;
            }
            else
            {
                empresa.Status = Enums.Status.Ativo;
            }
            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmpresaUpdateVO>(empresa);
        }

        public async Task<bool> Apagar(long id)
        {
            try
            {
                Empresa empresa = await _context.Empresas.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
                Endereco endereco = await _context.Endereco
                .Where(p => p.Id == empresa.EnderecoId)
                .FirstOrDefaultAsync();
                if (empresa == null) return false;
                _context.Empresas.Remove(empresa);
                _context.Endereco.Remove(endereco);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<PessoaVO>> TodasPessoasEmpresa(long id)
        {
            List<Pessoa> pessoas = await _context.Pessoas
                .Where(p => p.Empresa.Id == id)
                .Include(p => p.Empresa)
                .ToListAsync();
            var empresa = await _context.Empresas
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            empresa.Pessoas = pessoas;

            return _mapper.Map<List<PessoaVO>>(pessoas);
        }
        public async Task<bool> Atualizar_Status(long id)
        {
            Empresa empresa = await _context.Empresas.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            if (id <= 0 || empresa.Status == Enums.Status.Pendente) 
                return false;
            var teste = await TodasPessoasEmpresa(id);
            if (teste.Count != 0) return false;
            if (empresa.Status == Enums.Status.Ativo)
            {
                empresa.Status = Enums.Status.Inativo;
            }
            else
            {
                empresa.Status = Enums.Status.Ativo;
            }
                
            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
