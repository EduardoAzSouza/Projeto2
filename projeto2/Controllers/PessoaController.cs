using Microsoft.AspNetCore.Mvc;
using projeto2.API.Data.ValueObjects;
using projeto2.API.Repository;

namespace PessoaController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private IPessoaRepository _repository;

        public PessoasController(IPessoaRepository repository)
        {
            _repository= repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaVO>>> BuscarTodasPessoas()
        {
            var pessoas = await _repository.BuscarTodasPessoas();
            return Ok(pessoas);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PessoaVO>> BuscarPorID(long id)
        {
            var pessoa = await _repository.BuscarPorID(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }
        
        [HttpGet("{nome}")]
        public async Task<ActionResult<PessoaVO>> BuscarPorNome(string nome)
        {
            var pessoa = await _repository.BuscarPorNome(nome);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }
        
        [HttpPost]
        public async Task<ActionResult<PessoaVO>> Adicionar([FromBody] PessoaVO vo)
        {
            if (vo == null) return BadRequest();
            var pessoa = await _repository.Adicionar(vo);
            return Ok(pessoa);
        }

        [HttpPut]
        public async Task<ActionResult<PessoaVO>> Atualizar([FromBody] PessoaVO vo)
        {
            if (vo == null) return BadRequest();
            var pessoa = await _repository.Atualizar(vo);
            return Ok(pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(long id)
        {
            var status = await _repository.Apagar(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}