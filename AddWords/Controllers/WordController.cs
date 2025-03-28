using System.Security.Claims;
using AddWords.Controllers;
using AddWords.Data;
using AddWords.Dtos;
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
        public async Task<ActionResult<IEnumerable<Words>>> PostWord(WordCreateDTO word)
        {
            try 
            {
                var newWord = new Words()
                {
                    Name = word.Name
                };

                var translations = word.Translation.Select(c => new Translations
                {
                    Name = c.Name,
                    Context = c.Context,
                    Words = newWord
                }).ToList();

                newWord.Translations = translations;

                _context.Words.Add(newWord);

                return Ok(await _context.Words.Include(e => e.Translations).ToListAsync());
            }
            catch
            {
                return BadRequest("Erro desconhecido");
            }


        }

        private int ReturnUserIdToken()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var idUser = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            return Int32.Parse(identity.FindFirst("userId").Value);
        }


    }
}
