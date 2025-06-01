using FCG.Data;
using FCG.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DataContext _context;
        public RegisterController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<List<Users>>> Register(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Usuário cadastrado com sucesso!" });
        }
    }
}
