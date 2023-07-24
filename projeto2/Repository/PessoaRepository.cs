using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projeto2.API.Data.ValueObjects;
using projeto2.API.Model;
using projeto2.API.Model.context;
using System.Data;

namespace projeto2.API.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;
        public PessoaRepository(MySQLContext mySQLContext, IMapper mapper)
        {
            _context = mySQLContext;
            _mapper = mapper;
        }
        public async Task<PessoaViewVO> BuscarPorID(long id)
        {
            Pessoa pessoa = await _context.Pessoas.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<PessoaViewVO>(pessoa);
        }

        public async Task<List<PessoaViewVO>> BuscarPorNome(string nome)
        {
            List<Pessoa> pessoa = await _context.Pessoas.Where(p => p.Nome.Contains(nome))
                .ToListAsync();
            return _mapper.Map<List<PessoaViewVO>>(pessoa);
        }

        public async Task<IEnumerable<PessoaViewVO>> BuscarTodasPessoas()
        {
            List<Pessoa> pessoa = await _context.Pessoas
                .ToListAsync();
            return _mapper.Map<List<PessoaViewVO>>(pessoa);
        }

        public async Task<PessoaVO> Adicionar(PessoaVO vo)
        {
            Pessoa pessoa = _mapper.Map<Pessoa>(vo);
            var verficaDoc = await _context.Pessoas
                .Where(p => p.Documento == pessoa.Documento)
                .FirstOrDefaultAsync();
            var verificaTel = await _context.Pessoas
                .Where(p => p.Telefone == pessoa.Telefone)
                .FirstOrDefaultAsync();
            if (vo.Nome == null || vo.Telefone == null || vo.Documento == null || vo.Usuario == null ||
               vo.Nome.Trim() == "" || vo.Telefone.Trim() == "" || vo.Documento.Trim() == "" || vo.Usuario.Trim() == "")
            {
                pessoa.Status = Enums.Status.Pendente;
            }
            else
            {
                pessoa.Status = Enums.Status.Ativo;
            }

            if (verficaDoc == null && verificaTel == null)
            {
                _context.Pessoas.Add(pessoa);
                await _context.SaveChangesAsync();
                return _mapper.Map<PessoaVO>(pessoa);
            }
            else
            {
                pessoa = null;
                return _mapper.Map<PessoaVO>(pessoa);
            }
        }

        public async Task<PessoaUpdateVO> Atualizar(PessoaUpdateVO vo)
        {
            Pessoa pessoa = _mapper.Map<Pessoa>(vo);
            Pessoa pessoaDB = await _context.Pessoas
                .AsNoTracking()
                .Where(c => c.Id == pessoa.Id)
                .FirstOrDefaultAsync();

            pessoa.Documento = pessoaDB.Documento;
            pessoa.EmpresaId = pessoaDB.EmpresaId;


            if (vo.Nome == null || vo.Telefone == null || vo.Usuario == null ||
                vo.Nome.Trim() == "" || vo.Telefone.Trim() == "" || vo.Usuario.Trim() == "")
            {
                pessoa.Status = Enums.Status.Pendente;
            }
            else
            {
                pessoa.Status = Enums.Status.Ativo;
            }
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
            return _mapper.Map<PessoaUpdateVO>(pessoa);
        }

        public async Task<bool> Apagar(long id)
        {
            try
            {
                Pessoa pessoa = await _context.Pessoas.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
                if (id <= 0) return false;
                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Atualizar_Status(long id)
        {
            Pessoa pessoa = await _context.Pessoas.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            if (id <= 0 || pessoa.Status == Enums.Status.Pendente) return false;
            if (pessoa.Status == Enums.Status.Ativo)
            {
                pessoa.Status = Enums.Status.Inativo;
                pessoa.Empresa = null;
                pessoa.EmpresaId = null;
            }
            else pessoa.Status = Enums.Status.Ativo;
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<PessoaViewVO> vincular_empresa(long pessoa_id, long empresa_id)
        {
            Pessoa pessoa = await _context.Pessoas
                .Where(p => p.Id == pessoa_id)
                .FirstOrDefaultAsync();
            Empresa empresa = await _context.Empresas 
                .Where(c => c.Id == empresa_id)
                .FirstOrDefaultAsync();
            if (empresa == null) 
            {
                pessoa.Empresa = null;
                pessoa.EmpresaId = null;
                _context.Pessoas.Update(pessoa);
                await _context.SaveChangesAsync();
                return _mapper.Map<PessoaViewVO>(pessoa);
            }
            else if(pessoa.Status == Enums.Status.Ativo && empresa.Status == Enums.Status.Ativo)
            {
                pessoa.Empresa = empresa;
                _context.Pessoas.Update(pessoa);
                await _context.SaveChangesAsync();
                return _mapper.Map<PessoaViewVO>(pessoa);
            }
            else return _mapper.Map<PessoaViewVO>(pessoa);
        }
    }
}
