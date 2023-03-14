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

        public async Task<EmpresaVO> BuscarPorNome(string nome)
        {
            Empresa empresa = await _context.Empresas.Where(p => p.NomeFantasia == nome)
                .FirstOrDefaultAsync() ?? new Empresa();
            return _mapper.Map<EmpresaVO>(empresa);
        }

        public async Task<EmpresaVO> BuscarPorCnpj(string cnpj)
        {
            Empresa empresa = await _context.Empresas.Where(p => p.Cnpj == cnpj)
                .FirstOrDefaultAsync() ?? new Empresa();
            return _mapper.Map<EmpresaVO>(empresa);
        }

        public async Task<List<EmpresaVO>> BuscarTodasEmpresas()
        {
            List<Empresa> empresa = await _context.Empresas.ToListAsync();
            return _mapper.Map<List<EmpresaVO>>(empresa);
        }
        public async Task<EmpresaVO> Adicionar(EmpresaVO vo)
        {
            Empresa empresa = _mapper.Map<Empresa>(vo);
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmpresaVO>(empresa);
        }

        public async Task<EmpresaVO> Atualizar(EmpresaVO vo)
        {
            Empresa empresa = _mapper.Map<Empresa>(vo);
            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmpresaVO>(empresa);
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
