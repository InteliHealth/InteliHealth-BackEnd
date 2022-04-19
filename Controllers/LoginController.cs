using InteliHealth.Domains;
using InteliHealth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InteliHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.IdGoogle);

                if (login.Email == "" || login.IdGoogle == "")
                {
                    return BadRequest("Erro ao fazer login tente novamente");
                }

                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }
                else
                {
                    _usuarioRepository.Cadastrar(login);
                    Usuario novoUsuario = _usuarioRepository.Login(login.Email, login.IdGoogle);
                    return Ok(novoUsuario);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
