using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projeto2.API.Data.ValueObjects;
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

        public async Task<Empresa> BuscarPorNome(string nome)
        {
            Empresa empresa = await _context.Empresas.Where(p => p.NomeFantasia == nome)
                .Include(e => e.Endereco).FirstOrDefaultAsync() ?? new Empresa();
            return _mapper.Map<Empresa>(empresa);
        }

        public async Task<Empresa> BuscarPorCnpj(string cnpj)
        {
            Empresa empresa = await _context.Empresas.Where(p => p.Cnpj == cnpj)
                .Include(e => e.Endereco).FirstOrDefaultAsync() ?? new Empresa();
            return _mapper.Map<Empresa>(empresa);
        }

        public async Task<List<Empresa>> BuscarTodasEmpresas()
        {
            List<Empresa> empresa = await _context.Empresas.Include(e => e.Endereco).ToListAsync();
            return _mapper.Map<List<Empresa>>(empresa);
        }
        public async Task<EmpresaVO> Adicionar(EmpresaVO vo)
        {
            Empresa empresa = _mapper.Map<Empresa>(vo);
            if (vo.Cnpj == "string" || vo.DataAbertura == "string" || vo.NomeEmpresarial == "string" || vo.NomeFantasia == "string" || vo.NaturezaJuridica == "string" || vo.Telefone == "string" || vo.Capital == 0 ||
                vo.Cnpj.Trim() == "" || vo.DataAbertura.Trim() == "" || vo.NomeEmpresarial.Trim() == "" || vo.NomeFantasia.Trim() == "" || vo.NaturezaJuridica.Trim() == "" || vo.Telefone.Trim() == "" || vo.Endereco == null)
            {
                empresa.Status = Enums.Status.Pendente;
            }
            else
            {
                empresa.Status = Enums.Status.Ativo;
            }
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmpresaVO>(empresa);
        }

        public async Task<EmpresaUpdateVO> Atualizar(EmpresaUpdateVO vo)
        {
            Empresa empresa = _mapper.Map<Empresa>(vo);
            if (vo.Cnpj == "string" || vo.DataAbertura == "string" || vo.NomeEmpresarial == "string" || vo.NomeFantasia == "string" || vo.NaturezaJuridica == "string" || vo.Telefone == "string" || vo.Capital == 0 ||
                vo.Cnpj.Trim() == "" || vo.DataAbertura.Trim() == "" || vo.NomeEmpresarial.Trim() == "" || vo.NomeFantasia.Trim() == "" || vo.NaturezaJuridica.Trim() == "" || vo.Telefone.Trim() == "" || vo.Endereco == null)
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
                .FirstOrDefaultAsync() ?? new Empresa();
                if (empresa.Id <= 0) return false;
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
