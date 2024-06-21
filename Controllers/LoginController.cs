using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepositorio _LoginRepositorio;

        public LoginController(ILoginRepositorio LoginRepositorio)
        {
            _LoginRepositorio = LoginRepositorio;
        }

        [HttpGet("GetAllLogin")]
        public async Task<ActionResult<List<LoginModel>>> GetAllLogin()
        {
            List<LoginModel> login = await _LoginRepositorio.GetAll();
            return Ok(login);
        }

        [HttpGet("GetLoignId/{id}")]
        public async Task<ActionResult<LoginModel>> GetLoginId(int id)
        {
            LoginModel login = await _LoginRepositorio.GetById(id);
            return Ok(login);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginModel>> Login([FromBody] LoginModel LoginModel)
        {
            LoginModel login = await _LoginRepositorio.Login(LoginModel);
            return Ok(login);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<LoginModel>> InsertLogin([FromBody] LoginModel LoginModel)
        {
            LoginModel login = await _LoginRepositorio.InsertLogin(LoginModel);
            return Ok(login);
        }
    }
}
