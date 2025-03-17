using AddWords.Data;
using AddWords.Model;
using AddWords.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AddWords.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context) 
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        public async Task <ActionResult<User>> PostUser (User user)
        {
            var User = new UserService();

            if (User.ValidateEmail(user.Email) && user.Email != null)
            {
                var hashPassword = User.HashedPassword(user.Senha);
                user.Senha = hashPassword;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, User);
            }

            return BadRequest("Email inválido");

        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user) 
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return NoContent();

        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
