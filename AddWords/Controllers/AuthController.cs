using AddWords.Data;
using AddWords.Model;
using AddWords.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace AddWords.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {

        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(LoginResponseModel request)
        {
            if (string.IsNullOrWhiteSpace(request.Nome) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Login ou senha inválida");

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Nome == request.Nome);

            if(user == null || Verify(request.Password, user.Senha) == false)
                return BadRequest("Login ou senha inválida");

            var token = TokenService.GenerateToken(user);

            return Ok(token);
        }
    }
}
