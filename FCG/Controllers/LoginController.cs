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

        //[HttpPost("registrar")]
        ////public async Task<IActionResult> Registrar([FromBody] Usuario novoUsuario)
        //public Task<IActionResult> Registrar([FromBody] Usuario novoUsuario)
        //{
        //    //await _usuarioRepository.CreateUsuarioAsync(novoUsuario);
        //    //return Ok(new { mensagem = "Usuário criado com sucesso" });
        //}

        private static List<Usuario> usuarios = new List<Usuario>();

        [HttpPost("register")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verifica se já existe usuário com o mesmo e-mail
            if (usuarios.Any(u => u.Email == usuario.Email))
                return Conflict(new { mensagem = "E-mail já cadastrado" });

            usuarios.Add(usuario);

            return Ok(new { mensagem = "Usuário cadastrado com sucesso!" });
        }
    }
}
