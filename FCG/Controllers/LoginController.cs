using FCG.Model;
using FCG.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FCG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public LoginController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario request)
        {
            var usuario = await _usuarioRepository.GetUsuarioAsync(request.Username, request.Password);

            if (usuario == null)
                return Unauthorized(new { mensagem = "Usuário ou senha inválidos" });

            return Ok(new { mensagem = "Login bem-sucedido", usuario.Id, usuario.Username });
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] Usuario novoUsuario)
        {
            await _usuarioRepository.CreateUsuarioAsync(novoUsuario);
            return Ok(new { mensagem = "Usuário criado com sucesso" });
        }
    }
}
