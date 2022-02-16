using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly DataContext _context;

        public CharacterController(DataContext context)
        {
            _context = context;
        }


        // get charactors that belongs to user

        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacter(int userId)
        {
            var characters = await _context.Characters
                .Where(x => x.UserId == userId)
                .Include(y => y.Weapon)
                .Include(z => z.Skills)
                .ToListAsync();
            if (characters == null)
            {
                return BadRequest("Character not found");
            }

            return Ok(characters);
        }



        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return await GetCharacter(character.UserId);
        }



   

    }
}
