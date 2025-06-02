using FCG.Data;
using FCG.DTOs;
using FCG.Model;
using JWT_Example;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FCG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly DataContext _context;

        public AuthController(DataContext context, JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {

            var account = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginDto.Username);

            if (account == null)
                return BadRequest(new { mensagem = "Usuário não encontrado." });

            bool isSenhaCorreta = BCrypt.Net.BCrypt.Verify(loginDto.Password, account.Password);

            if (!isSenhaCorreta)
                return BadRequest(new { mensagem = "Senha incorreta." });

            var auth = new Auth.Auth(_jwtSettings);
            var token = auth.GerarAuth();

            return Ok(new
            {
                mensagem = "Login bem-sucedido",
                token = token
            });
            
        }
    }
}
