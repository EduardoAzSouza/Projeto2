using Microsoft.AspNetCore.Mvc;
using projeto2.API.Data.ValueObjects;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaVO>>> BuscarTodasEmpresas()
        {
            var empresas = await _repository.BuscarTodasEmpresas();
            return Ok(empresas);
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<EmpresaVO>> BuscarPorNome(string nome)
        {
            var empresa = await _repository.BuscarPorNome(nome);
            if (empresa == null) return NotFound();
            return Ok(empresa);
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaVO>> Adicionar([FromBody] EmpresaVO vo)
        {
            if (vo == null) return BadRequest();
            var empresa = await _repository.Adicionar(vo);
            return Ok(empresa);
        }

        [HttpPut]
        public async Task<ActionResult<EmpresaVO>> Atualizar([FromBody] EmpresaVO vo)
        {
            if (vo == null) return BadRequest();
            var empresa = await _repository.Atualizar(vo);
            return Ok(empresa);
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