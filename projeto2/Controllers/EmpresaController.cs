﻿using Microsoft.AspNetCore.Mvc;
using projeto2.API.Data.ValueObjects;
using projeto2.API.Model;
using projeto2.API.Repository;

namespace EmpresaController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private IEmpresaRepository _repository;
        public EmpresaController(IEmpresaRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet("BuscarTodasEmpresas")]
        public async Task<ActionResult<IEnumerable<EmpresaViewVO>>> BuscarTodasEmpresas()
        {
            var empresas = await _repository.BuscarTodasEmpresas();
            return Ok(empresas);
        }

        [HttpGet("BuscarPorNome/{nome}")]
        public async Task<ActionResult<EmpresaViewVO>> BuscarPorNome(string nome)
        {
            var empresa = await _repository.BuscarPorNome(nome);
            if (empresa == null) return NotFound();
            return Ok(empresa);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<EmpresaViewVO>> BuscarPorId(long id)
        {
            var empresa = await _repository.BuscarPorId(id);
            if (empresa == null) return NotFound();
            return Ok(empresa);
        }

        [HttpGet("BuscarPorCnpj/{cnpj}")]
        public async Task<ActionResult<EmpresaViewVO>> BuscarPorCnpj(string cnpj)
        {
            var empresa = await _repository.BuscarPorCnpj(cnpj);
            if (empresa == null) return NotFound();
            return Ok(empresa);
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<EmpresaVO>> Adicionar([FromBody] EmpresaVO vo)
        {
            if (vo == null) return BadRequest();
            var empresa = await _repository.Adicionar(vo);
            if (empresa != null)  return Ok(empresa);
            else return BadRequest("Já existe uma empresa com esse Cnpj");
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult<EmpresaUpdateVO>> Atualizar([FromBody] EmpresaUpdateVO vo)
        {
            if (vo == null) return BadRequest();
            if (vo.Id == 0) return BadRequest("Id não pode ser 0");
            var empresa = await _repository.Atualizar(vo);
            if (empresa != null) return Ok(empresa);
            else return BadRequest("Id invalido");
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<ActionResult> Apagar(long id)
        {
            var status = await _repository.Apagar(id);
            if (!status) return BadRequest("Existem Pessoas cadastradas na empresa");
            return Ok(status);
        }
        [HttpPut("alterar_status/{id}")]
        public async Task<ActionResult> Atualizar_Status(long id)
        {
            var status = await _repository.Atualizar_Status(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpGet("TodasPessoasEmpresa/{id}")]
        public async Task<ActionResult<IEnumerable<PessoaVO>>> TodasPessoasEmpresa(long id)
        {
            var pessoas = await _repository.TodasPessoasEmpresa(id);
            return Ok(pessoas);
        }
        
    }
}