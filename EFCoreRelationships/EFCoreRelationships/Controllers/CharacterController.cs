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
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var characters = await _context.Characters
                .Where(x => x.UserId == userId)
                .Include(y => y.Weapon)
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

            return await Get(character.UserId);
        }



        [HttpPost("weapon")]
        public async Task<ActionResult<Character>> AddWeapon(Weapon weapon)
        {

            var character = await _context.Characters.FindAsync(weapon.CharacterId);
            if (character == null)
                return NotFound();

            var newWeapon = new Weapon
            {
                Name = weapon.Name,
                Damage = weapon.Damage,
                Character = character
            };

            _context.Weapons.Add(newWeapon);
            await _context.SaveChangesAsync();

            return character; 
        }
    }
}
