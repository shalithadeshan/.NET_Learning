using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SkillController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Skill>>> GetSkills()
        {
            var skills = await _dataContext.Skills
                .ToListAsync();
            return Ok(skills);
        }

        [HttpPost]
        public async Task<ActionResult<Skill>> AddCharacterSkill(Skill skill)
        {

            //var character = await _context.Characters
            //    .Where(c => c.Id == request.CharacterId)
            //    .Include(c => c.Skills)
            //    .FirstOrDefaultAsync();
            //if (character == null)
            //    return NotFound();

            //var skill = await _context.Skills.FindAsync(request.SkillId);
            //if (skill == null)
            //    return NotFound();



            _dataContext.Skills.Add(skill);
            await _dataContext.SaveChangesAsync();

            var dbSkill = await _dataContext.Skills.ToListAsync();
            return Ok(dbSkill);
        }

        [HttpPut]
        public async Task<ActionResult<Skill>> UpdateSkill(Skill request)
        {
            var skill = await _dataContext.Skills.FindAsync(request.Id);
            if (skill == null)
                return BadRequest("Skill Not Find");

            skill.Name = request.Name;
            skill.Damage = request.Damage;
            skill.Characters = request.Characters;

            await _dataContext.SaveChangesAsync();

            var dbSkill = await _dataContext.Skills.ToListAsync();
            return Ok(dbSkill);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Skill>>> DeleteSkill(int id)
        {
            var skill = await _dataContext.Skills.FindAsync(id);
            if (skill == null)
                return BadRequest("Skill Not Find");

            _dataContext.Skills.Remove(skill);
            await _dataContext.SaveChangesAsync();

            var dbSkill = await _dataContext.Skills.ToListAsync();
            return Ok(dbSkill);
        }
    }
}
