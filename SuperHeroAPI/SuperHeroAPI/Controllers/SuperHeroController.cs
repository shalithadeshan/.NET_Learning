using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        //private static List<SuperHero> heros = new List<SuperHero>
        //    {
        //        new SuperHero {
        //            Id = 1,
        //            Name = "Spider-Man",
        //            FistName = "Peter",
        //            LastName = "Parker",
        //            Place = "New York City"
        //        },
        //         new SuperHero {
        //            Id = 2,
        //            Name = "Bat-Man",
        //            FistName = "Bruce",
        //            LastName = "Wayne",
        //            Place = "Gotham City"
        //        }
        //    };
        private readonly DataContext dataContext;

        public SuperHeroController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // get all heros

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await this.dataContext.SuperHeroes.ToListAsync());
        }


        // get a hero

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            //var hero = heros.Find(x => x.Id == id);
            var hero = await this.dataContext.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("hero not fund");
            }
            return Ok(hero);
        }


        // post a hero
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            //heros.Add(hero);
            this.dataContext.SuperHeroes.Add(hero);
            await this.dataContext.SaveChangesAsync();
            return Ok(await this.dataContext.SuperHeroes.ToListAsync());
        }

        // Update Hero
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            //var hero = heros.Find(x => x.Id == request.Id);
            var hero = await this.dataContext.SuperHeroes.FindAsync(request.Id);
            if (hero == null)
                return BadRequest("hero not fund");
            hero.Name = request.Name;
            hero.FistName = request.FistName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            await this.dataContext.SaveChangesAsync();
            var dbHero = await this.dataContext.SuperHeroes.ToListAsync();
            return Ok(dbHero);
        }

        // Delete hore
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = await this.dataContext.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("hero not fund");
            this.dataContext.SuperHeroes.Remove(hero);
            await this.dataContext.SaveChangesAsync();
            var dbHero = await this.dataContext.SuperHeroes.ToListAsync();
            return Ok(dbHero);
        }
    }
}
