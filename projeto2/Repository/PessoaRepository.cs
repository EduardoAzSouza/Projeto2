using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projeto2.API.Data.ValueObjects;
using projeto2.API.Model;
using projeto2.API.Model.context;
using System.Collections.Generic;

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
        public async Task<PessoaVO> BuscarPorID(long id)
        {
            Pessoa pessoa = await _context.Pessoas.Where(p => p.Id == id)
                .FirstOrDefaultAsync() ?? new Pessoa();
            return _mapper.Map<PessoaVO>(pessoa);
        }

        public async Task<PessoaVO> BuscarPorNome(string nome)
        {
            Pessoa pessoa = await _context.Pessoas.Where(p => p.Nome == nome)
                .FirstOrDefaultAsync() ?? new Pessoa();
            return _mapper.Map<PessoaVO>(pessoa);
        }

        public async Task<IEnumerable<PessoaVO>> BuscarTodasPessoas()
        {
            List<Pessoa> pessoa = await _context.Pessoas.ToListAsync();
            return _mapper.Map<List<PessoaVO>>(pessoa);
        }

        public async Task<PessoaVO> Adicionar(PessoaVO vo)
        {
            Pessoa pessoa = _mapper.Map<Pessoa>(vo);
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return _mapper.Map<PessoaVO>(pessoa);
        }

        public async Task<PessoaVO> Atualizar(PessoaVO vo)
        {
            Pessoa pessoa = _mapper.Map<Pessoa>(vo);
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
            return _mapper.Map<PessoaVO>(pessoa);
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
    }
}
