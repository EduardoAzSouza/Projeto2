using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projeto2.API.Data.ValueObjects;
using projeto2.API.Model;
using projeto2.API.Model.context;

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
        public async Task<Pessoa> BuscarPorID(long id)
        {
            Pessoa pessoa = await _context.Pessoas.Where(p => p.Id == id)
                .FirstOrDefaultAsync() ?? new Pessoa();
            return _mapper.Map<Pessoa>(pessoa);
        }

        public async Task<Pessoa> BuscarPorNome(string nome)
        {
            Pessoa pessoa = await _context.Pessoas.Where(p => p.Nome == nome)
                .FirstOrDefaultAsync() ?? new Pessoa();
            return _mapper.Map<Pessoa>(pessoa);
        }

        public async Task<IEnumerable<Pessoa>> BuscarTodasPessoas()
        {
            List<Pessoa> pessoa = await _context.Pessoas
                .Include(x => x.Empresa)
                    .ThenInclude(e => e.Endereco)
                .ToListAsync();
            return _mapper.Map<List<Pessoa>>(pessoa);
        }

        public async Task<PessoaVO> Adicionar(PessoaVO vo)
        {
            Pessoa pessoa = _mapper.Map<Pessoa>(vo);
            if (vo.Nome == "string" || vo.Telefone == "string" || vo.Documento == "string" || vo.Usuario == "string" ||
                vo.Nome.Trim() == "" || vo.Telefone.Trim() == "" || vo.Documento.Trim() == "" || vo.Usuario.Trim() == "")
            {
                pessoa.Status = Enums.Status.Pendente;
            }
            else
            {
                pessoa.Status = Enums.Status.Ativo;
            }
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return _mapper.Map<PessoaVO>(pessoa);
        }

        public async Task<PessoaUpdateVO> Atualizar(PessoaUpdateVO vo)
        {
            Pessoa pessoa = _mapper.Map<Pessoa>(vo);
            if (vo.Nome == "string" || vo.Telefone == "string" || vo.Documento == "string" || vo.Usuario == "string" ||
                vo.Nome.Trim() == "" || vo.Telefone.Trim() == "" || vo.Documento.Trim() == "" || vo.Usuario.Trim() == "")
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
                .FirstOrDefaultAsync() ?? new Pessoa();
                if (pessoa.Id <= 0) return false;
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
                .FirstOrDefaultAsync() ?? new Pessoa();
            if (pessoa.Id <= 0 || pessoa.Status == Enums.Status.Pendente) return false;
            if (pessoa.Status == Enums.Status.Ativo) pessoa.Status = Enums.Status.Inativo;
            else pessoa.Status = Enums.Status.Ativo;
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> vincular_empresa(long pessoa_id, long empresa_id)
        {
            Pessoa pessoa = await _context.Pessoas.Where(p => p.Id == pessoa_id)
                .FirstOrDefaultAsync() ?? new Pessoa();
            if (pessoa.Id <= 0 || pessoa.Status == Enums.Status.Pendente) return false;
            pessoa.EmpresaId = empresa_id;
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}
