using System;
using Microsoft.AspNetCore.Mvc;
using TestAPI.model;
using TestAPI.service;

namespace TestAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{
        private readonly SuperHeroService superHeroService;
        public SuperHeroController(SuperHeroService superHeroService)
        {
            this.superHeroService = superHeroService;
        }
        private static List<SuperHero> superHeroes = new List<SuperHero>
            {
                new SuperHero { Id = 1, Name = "Spider Man" , FirstName = "Peter" , LastName = "Parker" , Place = "New York"},
                new SuperHero { Id = 2, Name = "Iron Man", FirstName = "Tony", LastName = "Stark", Place = "Malibu" },
                new SuperHero { Id = 3, Name = "Wonder Woman", FirstName = "Diana", LastName = "Prince", Place = "Themyscira" },
                new SuperHero { Id = 4, Name = "Black Panther", FirstName = "T'Challa", LastName = "", Place = "Wakanda" }
            };
        [HttpGet]
		public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
		{
            return await superHeroService.GetAllHeroes();
		}

        [HttpGet("{Id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int Id)
        {
            var hero = await superHeroService.GetSingleHero(Id);
            if (hero is null)
                return NotFound("Hero doesnt exists!");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody]SuperHero superHero)
        {
            var result = await superHeroService.AddHero(superHero);
            
            return Ok(result);

        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<SuperHero>> UpdateHero(int Id, [FromBody]SuperHero superHero)
        {
            var result = await superHeroService.UpdateHero(Id,superHero);
            if (result is null)
                return NotFound("hero doesnt exists!");

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int Id)
        {
            var result = await superHeroService.DeleteHero(Id);
            if (result is null)
                return NotFound("hero doesnt exists!");

            return Ok(result);
        }
    }
}

