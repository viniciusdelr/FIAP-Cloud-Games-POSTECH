using FCG.Model;
using FCG.Repositories;
using JWT_Example;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FCG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly JwtSettings _jwtSettings;


        public LoginController(UsuarioRepository usuarioRepository, JwtSettings jwtSettings)
        {
            _usuarioRepository = usuarioRepository;
            _jwtSettings = jwtSettings;

        }

        [HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] Usuario novoUsuario)
        public IActionResult Login([FromBody] Usuario request)
        {
            //var usuario = await _usuarioRepository.GetUsuarioAsync(request.Username, request.Password);

            //if (usuario == null)
            //    return Unauthorized(new { mensagem = "Usuário ou senha inválidos" });

            //return Ok(new { mensagem = "Login bem-sucedido", usuario.Id, usuario.Username });

            if (request.Username == "USUARIOCORRETO")
            {
                var auth = new Auth.Auth(_jwtSettings);
                var token = auth.GerarAuth();

                return Ok(new
                {
                    mensagem = "Login bem-sucedido",
                    token = token
                });
            }
            else
            {
                return BadRequest(new
                {
                    mensagem = "Usuário ou senha inválidos"
                });
            }
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] Usuario novoUsuario)
        {
            await _usuarioRepository.CreateUsuarioAsync(novoUsuario);
            return Ok(new { mensagem = "Usuário criado com sucesso" });
        }
    }
}
