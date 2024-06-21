using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroRepositorio _CadastroRepositorio;

        public CadastroController(ICadastroRepositorio CadastroRepositorio)
        {
            _CadastroRepositorio = CadastroRepositorio;
        }

        [HttpGet("GetAllCadastros")]
        public async Task<ActionResult<List<CadastroModel>>> GetAllCadastros()
        {
            List<CadastroModel> cadastro = await _CadastroRepositorio.GetAll();
            return Ok(cadastro);
        }

        [HttpGet("GetCadastroId/{id}")]
        public async Task<ActionResult<CadastroModel>> GetCadastroId(int id)
        {
            CadastroModel cadastro = await _CadastroRepositorio.GetById(id);
            return Ok(cadastro);
        }

        [HttpPost("CreateCadastro")]
        public async Task<ActionResult<CadastroModel>> InsertCadastro([FromBody] CadastroModel CadastroModel)
        {
            CadastroModel cadastro = await _CadastroRepositorio.InsertCadastro(CadastroModel);
            return Ok(cadastro);
        }

    }
}

