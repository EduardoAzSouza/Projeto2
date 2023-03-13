using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using projeto2.API.Model;

namespace EmpresaController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private static List<Empresa> Empresas = new List<Empresa>();

        // Endpoint para cadastrar Empresas
        [HttpPost]
        public ActionResult<Empresa> CadastrarEmpresa(Empresa Empresa)
        {
            Empresa.Id = Empresas.Count + 1;
            Empresa.Status = "ativo";
            Empresas.Add(Empresa);
            return Ok(Empresa);
        }

        // Endpoint para listar Empresas
        [HttpGet]
        public ActionResult<List<Empresa>> ListarEmpresas()
        {
            return Ok(Empresas);
        }
    }
}