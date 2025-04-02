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
                Console.WriteLine("Token: " + UserIdToken);
                return await _context.Words.Include(e => e.Translations).Where(c => c.UserId.Equals(UserIdToken)).ToListAsync();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
                throw new Exception("Erro desconhecido");

            }

        }

        [Authorize]
        [HttpGet("{word}")]
        public async Task<ActionResult<IEnumerable<Words>>> GetWordsByName(string word)
        {
            try
            {
                int UserIdToken = ReturnUserIdToken();
                return await _context.Words.Include(e => e.Translations).Where(c => c.UserId.Equals(UserIdToken)).Where(c => c.Name.ToLower().Contains(word.ToLower())).ToListAsync();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
                throw new Exception("Erro desconhecido");
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Words>>> PostWord(WordCreateDTO word)
        {
            try 
            {
                int userIdToken = ReturnUserIdToken();

                var newWord = new Words
                {
                    Name = word.Name,
                    UserId = userIdToken
                };

                var translations = word.Translation.Select(c => new Translations
                {
                    Name = c.Name,
                    Context = c.Context,
                    Words = newWord
                }).ToList();

                newWord.Translations = translations;


                _context.Words.Add(newWord);
                await _context.SaveChangesAsync();

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

            return Int32.Parse(identity.FindFirst("userId").Value);
        }


    }
}
