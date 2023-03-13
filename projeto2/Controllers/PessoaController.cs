using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using projeto2.API.Model;

namespace PessoaController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();

        // Endpoint para cadastrar pessoas
        [HttpPost]
        public ActionResult<Pessoa> CadastrarPessoa(Pessoa pessoa)
        {
            pessoa.Id = pessoas.Count + 1;
            pessoa.Status = "ativo";
            pessoas.Add(pessoa);
            return Ok(pessoa);
        }

        // Endpoint para listar pessoas
        [HttpGet]
        public ActionResult<List<Pessoa>> ListarPessoas()
        {
            return Ok(pessoas);
        }
    }
}