using System.Security.Claims;
using AddWords.Data;
using AddWords.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AddWords.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordController : Controller
    {
        private readonly AppDbContext _context;

        public WordController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Words>>> GetWords()
        {
            try
            {
                int UserIdToken = ReturnUserIdToken();
                return await _context.Words.Where(c => c.UserId.Equals(UserIdToken)).ToListAsync();
            }
            catch (Exception) 
            {
                throw new Exception("Erro desconhecido");
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Words>>> PostWord(Words word, string translation)
        {
            word.UserId = ReturnUserIdToken();
            var newTranslation = 
            await _context.Add(word);
        }

        private int ReturnUserIdToken()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var idUser = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            return Int32.Parse(identity.FindFirst("userId").Value);
        }


    }
}
