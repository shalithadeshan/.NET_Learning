using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly DataContext _context;

        public WeaponController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<Weapon>>> GetWeapon()
        {
            var weapons = await _context.Weapons
                .Include(x => x.Character)
                .ToListAsync();
            return Ok(weapons);
        }



        [HttpPost]
        public async Task<ActionResult<Character>> AddWeapon(Weapon weapon)
        {

            //var character = await _context.Characters.FindAsync(weapon.CharacterId);
            //if (character == null)
            //    return NotFound();

            //var newWeapon = new Weapon
            //{
            //    Name = weapon.Name,
            //    Damage = weapon.Damage,
            //    Character = character
            //};

            _context.Weapons.Add(weapon);
            await _context.SaveChangesAsync();

            var dbWeapon = await _context.Weapons.ToListAsync();
            return Ok(dbWeapon);
        }



        [HttpPut]
        public async Task<ActionResult<Weapon>> UpdateWeapon(Weapon request)
        {
            var weapon = await _context.Weapons.FindAsync(request.Id);
            if (weapon == null)
                return BadRequest("Weapon Not Found");

            weapon.Name = request.Name;
            weapon.Damage = request.Damage;
            weapon.Character = request.Character;

            await _context.SaveChangesAsync();
            var dbWeapon = await _context.Weapons.ToListAsync();
            return Ok(dbWeapon);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Weapon>>> DeleteWeapon(int id)
        {
            var weapon = await _context.Weapons.FindAsync(id);
            if (weapon == null)
                return BadRequest("Weapon Not Fund");

            _context.Weapons.Remove(weapon);
            await _context.SaveChangesAsync();

            var dbWeapon = await _context.Weapons.ToListAsync();
            return Ok(dbWeapon);
        }
    }
}
