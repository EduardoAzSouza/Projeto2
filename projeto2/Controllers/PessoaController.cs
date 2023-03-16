using Microsoft.AspNetCore.Mvc;
using projeto2.API.Data.ValueObjects;
using projeto2.API.Enums;
using projeto2.API.Model;
using projeto2.API.Repository;
using System;

namespace PessoaController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private IPessoaRepository _repository;

        public PessoasController(IPessoaRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet("BuscarTodasPessoas")]
        public async Task<ActionResult<IEnumerable<Pessoa>>> BuscarTodasPessoas()
        {
            var pessoas = await _repository.BuscarTodasPessoas();
            return Ok(pessoas);
        }

        [HttpGet("BuscarPorID/{id}")]
        public async Task<ActionResult<Pessoa>> BuscarPorID(long id)
        {
            var pessoa = await _repository.BuscarPorID(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        [HttpGet("BuscarPorNome/{nome}")]
        public async Task<ActionResult<Pessoa>> BuscarPorNome(string nome)
        {
            var pessoa = await _repository.BuscarPorNome(nome);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<PessoaVO>> Adicionar([FromBody] PessoaVO vo)
        {
            if (vo == null) return BadRequest();
            var pessoa = await _repository.Adicionar(vo);
            return Ok(pessoa);
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult<PessoaUpdateVO>> Atualizar([FromBody] PessoaUpdateVO vo)
        {
            if (vo == null) return BadRequest();
            var pessoa = await _repository.Atualizar(vo);
            return Ok(pessoa);
        }

        [HttpDelete("Apagar/{id}")]
        public async Task<ActionResult> Apagar(long id)
        {
            var status = await _repository.Apagar(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpPut("alterar_status")]
        public async Task<ActionResult> Atualizar_Status(long id)
        {
            var status = await _repository.Atualizar_Status(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpPut("vincular_empresa")]
        public async Task<ActionResult<PessoaUpdateVO>> vincular_empresa(long pessoa_id, long empresa_id)
        {
            var status = await _repository.vincular_empresa(pessoa_id, empresa_id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}